# Unity & Oculus Profiler
* Unity와 Oculus연결 하기 위한 방법
```
adb 설치 후
adb forward --list
adb forward tcp:34999 localabstract Unity-{패키지명}
``` 
* 설정 후 build 세팅에서 Development Build , Autconnected Profiler를 설정한다.
* 설정후에도 바로 profiler가 작동하지 않은면
```
adb kill-server
adb start-server
adb devices 
adb tcp:34999 localabstract Uniy-{패키지명}
```
* 위와 같이 설정후 다시 진행한다.
* 태스트 결과 Rendering에 많은 성능부화가 있음
    * Draw call
        * CPU가 GPU에게 오브젝트를 그려라라는 명령을 내리는것
        * 그려라 라는 명령안에는 메시정보 , 택스쳐 정보 , 라이트 정보등 하나의 오브젝트를 그리기위한 담겨짐
        * **한프레임이 그려지는것은 CPU , GPU의 작업이 모두 끝났을때가 됨,게임 최적화를 위해서는 CPU의 부하인지 , GPU의 부하인지 체크를 해야함**
        * Unity에서는 Batch(그리라는 명령 + 상태 변경)을 넓은 의미의 Draw Call이라고하면 setPass는 쉐이더로 인한 렌더링 패스 횟수를 이야기한다.
    * batch 
    




# jikij-Maunfacturing-Chungbuk_VR_Contest-
I implemented jikji manufacturing with undergraduate students using unity and blender



# WEBView >> VR Webview 다시 시작하기!!
https://github.com/IanPhilips/UnityOculusAndroidVRBrowser

