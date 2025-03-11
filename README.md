HFSM을 사용하여 캐릭터의 이동을 구현 하였습니다.

제가 구현한 HFSM특성상 캐릭터의 이동이 플레이어의 입력과 강하게 결합 되어 있어서 강의 내용을 토대로 합치려고 하다 보니 어려움이 있었습니다.

계층형 유한 상태 머신을 사용하여 캐릭터의 자연스러운 이동을 구현 하였고, FloatingCapsule을 사용하여 지형지물의 턱을 자연스럽게 올라갈 수 있도록 구현 하였습니다.
![image](https://github.com/user-attachments/assets/3896c1f1-da28-49a4-93e0-924c7d25765d)
![image](https://github.com/user-attachments/assets/8bd029b7-0152-42f6-9f4e-4a7bf91c7e88)

또한, 경사로에 따라서 이동속도 및 점프 높이를 조절 하였습니다.

Item을 ScriptableObject로 구현 하였고, Character의 세부 사항 또한 ScriptableObject로 구현 하였습니다.
![image](https://github.com/user-attachments/assets/798e7bfb-6f0b-4b09-917b-d0f133a26802)
