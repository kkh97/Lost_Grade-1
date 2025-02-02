using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
    [SerializeField]
    protected Vector3 _destPos;

    [SerializeField]
    protected Define.State _state = Define.State.Idle;

    [SerializeField]
    protected GameObject _lockTarget;

    public Define.WorldObject WorldObjectType { get; protected set; } = Define.WorldObject.Unknown;

    public virtual Define.State State
    {
        get { return _state; }
        set
        {
            _state = value;

            if (name.Contains("Player"))
            {
                Animator anim = GetComponent<Animator>();

                switch (_state)
                {
                    case Define.State.Die:
                        anim.CrossFade("DIE", 0.1f);
                        break;
                    case Define.State.Idle:
                        anim.CrossFade("WAIT", 0.1f);
                        break;
                    case Define.State.Moving:
                        anim.CrossFade("RUN", 0.1f);
                        break;
                    case Define.State.Skill:
                        anim.CrossFade("ATTACK", 0.1f, -1, 0);
                        break;
                    case Define.State.Skill1:
                        anim.CrossFade("SKILL1", 0.1f, -1, 0);
                        break;
                }
            }
            else if (name == "Spider")
            {
                Animation anim = GetComponentInChildren<Animation>();

                switch (_state)
                {
                    case Define.State.Die:
                        anim.CrossFade("death1", 0.1f);
                        break;
                    case Define.State.Idle:
                        anim.CrossFade("idle", 0.1f);
                        break;
                    case Define.State.Moving:
                        anim.CrossFade("run", 0.1f);
                        break;
                    case Define.State.Skill:
                        anim.CrossFade("attack2_new", 0.1f);
                        break;
                }
            }
            else
            {
                Animator anim = GetComponent<Animator>();

                switch (_state)
                {
                    case Define.State.Die:
                        anim.CrossFade("DIE", 0.1f);
                        break;
                    case Define.State.Idle:
                        anim.CrossFade("WAIT", 0.1f);
                        break;
                    case Define.State.Moving:
                        anim.CrossFade("RUN", 0.1f);
                        break;
                    case Define.State.Skill:
                        anim.CrossFade("ATTACK", 0.1f, -1, 0);
                        break;
                }
            }
        }
    }

    private void Start()
    {
        Init();
    }

    void Update()
    {
        switch (State)
        {
            case Define.State.Die:
                UpdateDie();
                break;
            case Define.State.Moving:
                UpdateMoving();
                break;
            case Define.State.Idle:
                UpdateIdle();
                break;
            case Define.State.Skill:
                UpdateSkill();
                break;
            case Define.State.Skill1:
                UpdateSkill1();
                break;
        }
    }

    public abstract void Init();

    protected virtual void UpdateDie() { }
    protected virtual void UpdateMoving() { }
    protected virtual void UpdateIdle() { }
    protected virtual void UpdateSkill() { }
    protected virtual void UpdateSkill1() { }
}
