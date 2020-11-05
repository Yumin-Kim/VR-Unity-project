# 최대한 정리하면서!!
# VR 작업하며 문제 사항들 정리
## OVR 관련 Class는 2019버전 관련 자료 조사
- Teleport    
    teleport 구현 하는데 있어 Oculus Integration이 업데이트에 따라 구현 부분이 많이 달라 진거 같다    
    방법은 최신 업데이트를 하지않고 2019버전을 이용한다    
    [Teleport 구현했지만 뒤로만 가는것을 방지해줌](https://forum.unity.com/threads/why-am-i-being-pushed-backwards-by-teleport.765638/)      
    위에 있는 파일을 덮어 쓰기 하고난 후에는 LocomotionController Class의 멤버변수를 수정 해주어야한다.     
    ```
        아래와 같이 멤버 변수의 수정이 필요하다.
        public OVRCameraRig CameraRig;
        public CharacterController CharacterController;
        public OVRPlayerController PlayerController;
    ```    
- 포탈 구현    
- 객체 잡기
    햔재 잡는 부분에서 에러 발생 튕기거나 다른 방향으로 의미없이 날라감!!    
    **Class Extend 하는 방향으로 재수정 요함 >> GrabObject_Class를 활용할 예정**
```
Update OVRGrabbable Class 132code 
따로 AudioSource를 추가 하든가 조건문을 추가 하여 에러 막아야함!!
virtual public void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        checkToGrab = false;
        m_grabbedBy = hand;
        m_grabbedCollider = grabPoint;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        //gameObject.GetComponent<AudioSource>().Play(); ///////////////////////////////////////////////////////////////////////////
    }        
```
# 최적화 관련
* 분석중 (컴퓨터 프로파일링 결과)
* 안드로이드 빌드시 최소화 하는 방법
* 최적화 진행 순서 **거의 Rendering 하는 부분에서 많은 자원을 잡아 먹는거 같음**
    1. 안드로이드 빌드 할떄 빌드 경량화
    2. 병목 현상 체크를 위해 프로파일링 진행
        * 초반 Unity 실핼 과정에서 엄청 튀는 모습을 볼수 있음 
    3. 1027결과 랜더링 부분에 많은 문제 발견
        * 그래픽 부분 ( 조명 , 애니메이션등등 차차 정리 필요 )
        * 잡은 물건을 던졌을때 극심한 Rendering 발생    
    4. 스크립트 간의 문제 unity 초반 빌드시 Start 함수에 instate 할 Object를 Resoures에서 load 하는 부분에서 문제가 발생하는것 같음
* 안드로이드 프로파일링 하는 방법 **오큘로스 캐스팅이 환경이 구축 되었을때를 가정하고 진행 한다.**
    1. adb forward 명령어를 통해 tcp port 34999 지정후 진행 >> 문제 발생시 밑에 있는 링크 참고
    2. build 할때 Development build , auto profiling 체크  
    3. run and build 하기 !!        
    [2020 안드로이드 프로파일링 하는 방법 관련 블로그 >> 2018.3.of2](https://happysalmon.tistory.com/9?category=821957)
* 카메라 각도에 따라 움직임 제어    
    애니메이션 제어 , 
* 그래픽 관련    
    조명 ::MeshRender >> Dynamic Occlusion 활성화(사용자 보이는 시점에서)     
* library 폴더가 3GB정도 잡아 먹고 있는 상황 >> 삭제해서 git 업로드는 상관 없지만 패키지 간에 문제가 있다는 정보들이 있다
## 자료
1. [스레드 관련 자료](https://sweetjey.tistory.com/85) >>> [Rescource](https://stackoverflow.com/questions/58729409/unity-calling-resources-load-from-a-different-thread)
2. [카메라범위 안에 있는 객체 확인 스레드](http://blog.naver.com/PostView.nhn?blogId=10ro&logNo=220895900463&categoryNo=0&parentCategoryNo=0&viewDate=&currentPage=1&postListTopCurrentPage=1&from=postView)
3. [안드로이드 프로파일링 ㅈ 버그 발견](https://forum.unity.com/threads/android-device-cant-able-to-connect-with-profiler-window.663376/)
4. [유니티 최적화 기법](https://nogan.tistory.com/7)
5. [유니티 안드로이드 최적화 빌드](http://batmask.net/index.php/2018/08/28/138/)
# Oculus Intergration 보다 다른 API 이용 하기
* [유니티 VR](https://www.youtube.com/watch?v=gGYtahQjmWQ) 
## 11 05일
* 수정 할 부분!
    * 2층
        * 게임 랜덤으로 변경 XX
        * 음성 지원은 게임 시작 할때 마다 재생 가능하게 XX
        * 2층에 직지 배치 - 규민 배치 >> 배치 후에 문제 발생시 해결 방안 동적으로 생성한 객체 재활용 방법
    * 1층
        * 책자 배치 최대한 비공간에 배치
        * 1층 돌덩이 잡고 어느 범위안에서만 가지고 놀 수 있도록
        * 
    * Teleport 후에 움직아상해짐
    * 조명 Bake 다시 진행
    * 박스 안에 로고 배치시 3D에서 이미지로 변경
* 디테일 추가 부분 
    * 2층 UI 개선
        * popup text로 게임 진행도 설명 및 스테이지 안내
        * 
