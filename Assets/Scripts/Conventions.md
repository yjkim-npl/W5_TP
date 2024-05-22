### General
- 길어진 폴더/파일명은 .md 파일에 약자로 표기해두기
    - 예시: Controller/PlayerAnimationController.cs -> Controller/PAC.cs
- 깃 커밋은 한글로 알아보기 쉽게
- 길어진 함수명은 .md 파일에 약자로 표기해두기

### 깃 컨벤션!
- 사용법
    - 예시: "점프 파일 생성"
- 커밋 규칙!
    - 생성: 게임매니저 스크립트 생성
    - 삭제: 플레이어 프리팹 삭제
    - 기능추가: 인풋시스템 추가
    - 기능제거: 카메라에 붙은 컴포넌트 제거
    - 이미지수정: 타일 맵 추가

### 코드 컨벤션!
1. 변수 camelCase ('_' )
    - (o) int playerNum = 0;
    - (x) int player_num = 0;
    - (o) string playerName = "asdf";
2. 함수, 클래스 등 나머지는 Pascal
    - (o) class MyClass
    - (x) class kebab-case
3. 작업은 씬을 분할하여 작업 후 마무리할 때 다같이 화면 공유하고 합치기
    - 김용준 작업 -> 오직 dev_YJKIM 씬에서만 (논의 없을시)

### 폴더 + 파일 + 함수 명 사전
#### 필수로 추가할 것

AC.cs = AnimationController.cs
BC.cs = BaseController.cs
CAC.cs = CharacterAnimationController.cs
CI.cs = CharacterInform.cs
DM.cs = DataManager.cs
GE.cs = GameExit.cs
GMS.cs = GameManagerSingle.cs
GS.cs = GameStart.cs
GSS.cs = GameStartSetting.cs
M.cs = Meteor.cs
PB.cs = PauseBtn.cs
PICS.cs = PlayerInputControllerSingle.cs
PMS.cs = PlayerMovementSingle.cs
SSAC.cs = SelectSceneAnimationController.cs
SSG.cs = SelectSceneGameManager.cs
GS.cs = GameStart.cs
GE.cs = GameExit.cs
PB.cs = PauseBtn.cs
AM.cs = AudioManager.cs
SSUI.cs = SelectSceneUI.cs
rFE = rendererFallingEffect
CP.cs = CollisionPlay.cs
