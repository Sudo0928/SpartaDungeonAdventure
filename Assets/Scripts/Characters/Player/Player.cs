using System;
using UnityEngine;

namespace GenshinImpactMovementSystem
{
    [RequireComponent(typeof(PlayerInput))]
    public class Player : MonoBehaviour
    {
        [field: Header("References")]
        [field: SerializeField] public PlayerSO Data { get; private set; }

        [field: Header("Collisions")]
        [field: SerializeField] public PlayerCapsuleColliderUtility ColliderUtility { get; private set; }
        [field: SerializeField] public PlayerLayerData LayerData { get; private set; }

        [field: Header("Camera")]
        [field: SerializeField] public PlayerCameraUtility CameraUtility { get; private set; }

        [field: Header("Animations")]
        [field: SerializeField] public PlayerAnimationData AnimationData { get; private set; }
        
        public RigidbodyReciver RigidbodyReciver { get; private set; }
        public Rigidbody Rigidbody {  get; private set; }
        public Animator Animator { get; private set; }
        public Transform MainCameraTransform { get; private set; }
        public PlayerInput Input {  get; private set; }

        public PlayerCondition condition;
        public Interaction Interaction { get; private set; }

        public ItemData itemData;
        public Action addItem;

        public Transform dropPosition;

        private PlayerMovementStateMachine movementStateMachine;

        #region Unity Methods

        private void Awake()
        {
            CharacterManager.Instance.Player = this;

            RigidbodyReciver = GetComponent<RigidbodyReciver>();
            Rigidbody = GetComponent<Rigidbody>();
            Animator = GetComponentInChildren<Animator>();

            condition = GetComponent<PlayerCondition>();

            Input = GetComponent<PlayerInput>();
            Input.Init();

            ColliderUtility.Initialize(gameObject);
            ColliderUtility.CalculateCapsuleColliderDimensions();
            CameraUtility.Initialize();
            AnimationData.Initialize();

            MainCameraTransform = Camera.main.transform;

            movementStateMachine = new PlayerMovementStateMachine(this);

            Interaction = GetComponent<Interaction>();
            Interaction.Init(this);
        }

        private void OnValidate()
        {
            ColliderUtility.Initialize(gameObject);
            ColliderUtility.CalculateCapsuleColliderDimensions();
        }

        private void Start()
        {
            movementStateMachine.ChangeState(movementStateMachine.IdlingState);
        }

        private void OnTriggerEnter(Collider collider)
        {
            movementStateMachine.OnTriggerEnter(collider);
        }

        private void OnTriggerExit(Collider collider)
        {
            movementStateMachine.OnTriggerExit(collider);
        }

        private void Update()
        {
            movementStateMachine.HandleInput();
            movementStateMachine.Update();
        }

        private void FixedUpdate()
        {
            movementStateMachine.PhysicsUpdate();
        }

        public void OnMovementStateAnimationEnterEvent()
        {
            movementStateMachine.OnAnimationEnterEvent();
        }

        public void OnMovementStateAnimationExitEvent()
        {
            movementStateMachine.OnAnimationExitEvent();
        }

        public void OnMovementStateAnimationTransitionEvent()
        {
            movementStateMachine.OnAnimationTransitionEvent();
        }

        #endregion

        #region Main Methods

        public void OnInteract(ItemData data)
        {
            itemData = data;
            addItem?.Invoke();
        }

        #endregion
    }
}
