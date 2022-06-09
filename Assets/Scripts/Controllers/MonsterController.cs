using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : BaseController
{
    Stat _stat;

    [SerializeField]
    float _scanRange = 10.0f;

    [SerializeField]
    float _attackRange = 2.0f;

    //ǥ�ø�ũ ������Ʈ
    [SerializeField]
    GameObject selectMark;

    //�ǰ�ȿ��
    [SerializeField]
    ParticleSystem hitEffect;
    [SerializeField]
    ParticleSystem skillEffect1;

    public override void Init()
    {
        WorldObjectType = Define.WorldObject.Monster;
        _stat = gameObject.GetComponent<Stat>();

        if (gameObject.GetComponentInChildren<UI_HPBar>() == null)
            Managers.UI.MakeWorldSpaceUI<UI_HPBar>(transform);

        //�����Ǿ��� �� ���� �ʱ�ȭ
        State = Define.State.Idle;

        //ǥ�ø�ũ�� ����
        HideSelection();

        //�ǰ�ȿ�� ����
        hitEffect.Stop();
        skillEffect1.Stop();
    }

    //ǥ�ø�ũ�� ����
    public void HideSelection()
    {
        selectMark.SetActive(false);
    }
    //ǥ�ø�ũ�� ������
    public void ShowSelection()
    {
        selectMark.SetActive(true);
    }

    //�ǰ�ȿ�� ���
    public void ShowHitEffect()
    {
        hitEffect.Play();
    }
    public void ShowSkillEffect1()
    {
        skillEffect1.Play();
    }

    protected override void UpdateIdle()
    {
        GameObject player = Managers.Game.GetPlayer();
        if (player == null || player.GetComponent<PlayerController>().State == Define.State.Die)
            return;

        float distance = (player.transform.position - transform.position).magnitude;
        if (distance <= _scanRange)
        {
            _lockTarget = player;
            State = Define.State.Moving;
            return;
        }

        //�׾��� �� ���� ����
        if (_stat.Hp <= 0)
        {
            State = Define.State.Die;
            return;
        }
    }

    protected override void UpdateMoving()
    {
        if (_lockTarget != null)
        {
            _destPos = _lockTarget.transform.position;
            float distance = (_destPos - transform.position).magnitude;
            if (distance <= _attackRange)
            {
                NavMeshAgent nma = gameObject.GetOrAddComponent<NavMeshAgent>();
                nma.SetDestination(transform.position);
                State = Define.State.Skill;
                return;
            }
        }

        Vector3 dir = _destPos - transform.position;
        if (dir.magnitude < 0.1f)
        {
            State = Define.State.Idle;
        }
        else
        {
            NavMeshAgent nma = gameObject.GetOrAddComponent<NavMeshAgent>();
            nma.SetDestination(_destPos);
            nma.speed = _stat.MoveSpeed;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 20 * Time.deltaTime);
        }

        //�׾��� �� ���� ����
        if (_stat.Hp <= 0)
        {
            State = Define.State.Die;
            return;
        }
    }

    protected override void UpdateSkill()
    {
        if (_lockTarget != null)
        {
            Vector3 dir = _lockTarget.transform.position - transform.position;
            Quaternion quat = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Lerp(transform.rotation, quat, 20 * Time.deltaTime);
        }

        //�����̴��� �̻��ϰ� ������ �ѹ��� �ؼ� ����
        if (name == "Spider")
        {
            _destPos = _lockTarget.transform.position;
            float distance = (_destPos - transform.position).magnitude;
            if (distance > _attackRange)
            {
                State = Define.State.Moving;
            }
            else
            {
                State = Define.State.Skill;
            }
        }

        //�÷��̾ �׾��� �� ������ ����
        if (_lockTarget.GetComponent<PlayerController>().State == Define.State.Die)
        {
            State = Define.State.Idle;
            return;
        }

        //�׾��� �� ���� ����
        if (_stat.Hp <= 0)
        {
            State = Define.State.Die;
            return;
        }
    }

    public void OnHitEvent()
    {
        if (_lockTarget != null)
        {
            Stat targetStat = _lockTarget.GetComponent<Stat>();

            if (targetStat.Hp > 0)
            {
                float distance = (_lockTarget.transform.position - transform.position).magnitude;
                if (distance <= _attackRange)
                {
                    targetStat.OnAttacked(_stat);
                    Managers.Sound.Play("Effects/EnemyHit");

                    State = Define.State.Skill;
                }
                else
                {
                    State = Define.State.Moving;
                }
            }
            else
            {
                State = Define.State.Idle;
            }
        }
        else
        {
            State = Define.State.Idle;
        }
    }
}
