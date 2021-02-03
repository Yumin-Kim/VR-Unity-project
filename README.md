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
    
* 진행에 있어 Rendering에 문제가 많은점들을 확인했지만 코드자체에 문제가 있는것이 아니였고 3D model의 mesh(폴리곤)의 갯수가 너무 많이 존재하여 랜더링하는 부분에 성능저하가 발생하여 많은 어려움 발생
* 해결 방안으로는 Blender를 활용하여 폴리곤을 제거하여 export한후에 다시 unity로 가져와 프로젝트를 진행하였는데 Rendering에 성능 개선이 확인 되었다.

# jikij-Maunfacturing-Chungbuk_VR_Contest-
I implemented jikji manufacturing with undergraduate students using unity and blender

# WebView >> VR Webview 다시 시작하기!!
https://github.com/IanPhilips/UnityOculusAndroidVRBrowser

# Latest developed technology[VR , AI , Web]
1. [Unity_3D_K] Oculus Intergration을 활용하여 Controller Interaction 구현[ 잡기 , 텔레포트 ]
   * Oculus Intergration
      * 해당 plugin보다 SteamVR 다양한 유튜브 영상 있음
   * SteamVR 
      * 해당 Plugin을 사용 권장!
2. [Unity_3D_K] 아바타 SDK 사용 [응용X]
   * 다른 수단을 통해서 사용자의 사진을 받아 서버에 저장후 unity에서 export하는 부분 구현 또는 unity에서 확인 가능한지 여부확인 필요!
3. [Unity_3D_K] 3DUnity 환경의 WebView
   * 개선점 :  Scene전환시 오류 발생 , 성능 개선 필요
4. [Unity_3D_S] 포톤서버 농구 게임
   * 미확인
5. [Unity_WebGL_K] WebGL로 빌드하여 Oculus Browser에서 web에서 가상환경으로 전환 가능 
   * 개선점 : 잡는 기능밖에 안됨 , loading속도 매우 느림
6. [Node.js_Web_K] Aframe을 활용하여 WebVR 구현
   * Oculus Browser 환경에서 구현 사이트 접속시 Unity에서 구현한 Interaction 구현 가능(잡기 텔레포트 이동) 
   * Socket을 활용한 멀티 접속
      * 개선점 : Room 별로 사용자 입장
   * Import custom 3D model
      * 개선점 : Heroku[서버]이용시 3Dmodel Load하는 시간이 많이 소모 >> AWS S3 , multer-s3를 활용하여 resize[lamda]을 활용하여 속도 개선 필요 
   * React-aframe
      * 개선점 : aframe = 1.0.4 버전이하로 Oculus Browser에서 가상환경으로 전환되지 않음 , webpack을 사용했기 때문에 성능개선은 되지만 복잡성 높아짐
      * 기존의 코드보다 유지보수 , 재활용성이 기존에 구현방식과 비교하여 좋음
7. [Node.js_React_Web_K] React를 사용하여 360페이지 제작
   * Webpack , babel
8. [Cloud Hosting service] Heroku , AWS 사용
   * Heroku
      * 무료 클라우드 호스팅 업체임으로 속도 느림 [테스트용 권장]
   * AWS
      * 유료 클라우드 호스팅 업체임으로 속도 및 보안 측면에서 우월 , 실제 공모전 , 과제시 사용[실서비스용 권장]
         * EC2
         * S3
9. 
      

