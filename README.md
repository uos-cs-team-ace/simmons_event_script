### SIM:MONS 이벤트 ###

**이벤트 스크립트 개요**
- Event 컴포넌트<br/>
  이벤트 발생의 대상 객체 정보들을 포함한다. 이벤트가 발생했을 시 사용할 속성변수값들을 포함한다. 이벤트의 발생대기시간, 발생한 시간등의 이벤트 정보를 포함한다.
  
- DragSlot 컴포넌트<br/>
  이벤트를 생성할때 이벤트 슬롯을 드래그하면 해당 이벤트슬롯의 정보가 일시적으로 담기는 클래스이다.
  
- EventBlock 컴포넌트<br/>
  이벤트의 유저인터페이스 부분을 담당할 클래스이다. 유저에게 보여지는 입력UI와 이벤트정보를 포함한다. 입력UI에 변동이 생겼을 때 이벤트수정작업을 처리한다.

- EventHandler 컴포넌트<br/>
  이벤트를 생성할 때 드래그 해제에 대한 처리를 담당하는 클래스이다. 이벤트슬롯을 드래그하여 드래그를 해제하였을때 적절한 위치에서 해제되었다면 DragSlot에 저장된 이벤트 정보를 사용하여 이벤트 블록을 생성한다.

- EventSlot 컴포넌트<br/>
  이벤트 블록과 연결된 슬롯 UI의 정보를 포함하고 있다.

- EventInformation 컴포넌트<br/>
  이벤트 블록의 입력값과 관련된 저장정보를 포함하고 있다.

**이벤트 목록**

( ' : simobject / " : attribute / "' : number / "" : flag)
- 이벤트 1: A' B' 충돌시 A'의 타입 C'로 변경
- 이벤트 2: A'의 B''가 조건C(Over, Under, Equl, Differ) D"'을 만족하면 A의 타입 E'로 변경
- 이벤트 3: A"''가 경과하면 B'를 C"'개 FlagD""의 위치에 한번 생성
- 이벤트 4: A' B' 충돌시 해당 위치에 C'를 D"'개 한번 생성
- 이벤트 5; A"'초마다 모든 B' 의 속도를 (C"', D"')로 변경
- 이벤트 6: A'가 FlagB""에 근접하면 A'의 목적지를 FlagC""로 변경
- 이벤트 7: A'가 FlagB""에 근접하면 A'의 C"를 조건D(Increase, Decrease, Replace to) E"'를 수행
- 이벤트 8: A"'초마다 모든 B'의 C"를 조건D(Increase, Decrease, Replace to) E"'를 수행
- 이벤트 9: A'가 FlagB""에 근접하면 A'의 속력 C"'로 변경
- 이벤트 10: A' B' 충돌시 A'의 속력을 C"'로 변경
- 이벤트 11: A' B' 충돌시 속도를 (C"', D"')로 변경
- 이벤트 12: A' B' 충돌시 A'의 목적지를 FlagC""로 변경
- 이벤트 13: A' B' 충돌시 A'의 C"를 조건D(Increase, Decrease, Replace to) E"'를 수행
- 이벤트 14: A' B' 충돌시 A' 삭제
- 이벤트 15: A"'초마다 B"'개 랜덤 C' 삭제
- 이벤트 16: A'의 B"가 (Over, Under, Equl, Differ) C"'을 만족하면 A' 삭제
- 이벤트 17: A'의 B"가 (Over, Under, Equl, Differ) C"'을 만족하면 A' 속력을 D"'로 변경
- 이벤트 18: A'의 B"가 (Over, Under, Equl, Differ) C"'을 만족하면 A' Movetype을 D로 변경
- 이벤트 19: A'의 B"가 (Over, Under, Equl, Differ) C"'을 만족하면 D"'초마다 E'를 F"'개 생성
- 이벤트 20: A'의 B"가 (Over, Under, Equl, Differ) C"'을 만족하면 A' 속도를 (D"', E"')로 변경
- 이벤트 21: A'의 B"가 (Over, Under, Equl, Differ) C"'을 만족하면 A' 목적지를 FlagD""로 변경
- 이벤트 22: A'의 B"가 (Over, Under, Equl, Differ) C"'을 만족하면 조건D(Increase, Decrease, Replace to) E"'를 수행
- 이벤트 23: A"' 초가 경과하면 모든 B'의 타입을 C'로 1회 변경
- 이벤트 24: A"' 초가 경과하면 모든 B'의 Movetype을 C로 1회 변경
- 이벤트 25: A"' 초가 경과하면 모든 B'의 속도를 (C"', D"')로 1회 변경
- 이벤트 26: A"' 초가 경과하면 모든 B'의 속력을 C"'로 1회 변경
- 이벤트 27: A"' 초가 경과하면 모든 B'의 목적지 FlagC""로 1회 변경
- 이벤트 28: A"' 초가 경과하면 모든 B'의 C" 조건D(Increase, Decrease, Replace to) E"'를 1회 수행
- 이벤트 29: A"' 초가 경과하면 모든 B'를 1회 삭제
- 이벤트 30: A"' 초가 경과하면 모든 B' 중 랜덤 C"'개 타입을 D'로 변경
- 이벤트 31: A"' 초가 경과하면 B' C"'개를 FlagD""에 생성
- 이벤트 32: A"' 초가 경과하면 모든 B'의 Movetype을 C로 변경
- 이벤트 33: A"' 초가 경과하면 모든 B'의 속력을 C"'로 변경
- 이벤트 34: A"' 초가 경과하면 모든 B'의 목적지를 FlacC""로 변경
- 이벤트 35: A"가 FlagB""에 근접하면 객체타입을 C'로 변경
- 이벤트 36: A'가 FlagB""에 근접하면 객체A' 를 FlagC""에 D"'개 생성
- 이벤트 37: A'가 FlagB""에 근접하면 Movetype을 C로 변경
- 이벤트 38: A'가 FlagB""에 근접하면 속도를 (C"', D"')로 변경
- 이벤트 39: A'가 FlagB""에 근접하면 객체 A' 삭제
- 이벤트 40: A' B' 충돌시 Movetype을 C로 변경
- 이벤트 41: A"' 초마다 모든 객체 B' 가 가장 가까운 객체 C'로 목적지 변경
- 이벤트 42: A' B' 충돌시 A'가 가장 가까운 객체 C'로 목적지 변경
- 이벤트 43: A'가 FlagB""에 근접하면 가장 가까운 객체 C'로 목적지 변경
- 이벤트 44: A"'시간이 경과하면 모든 객체B'가 가장 가까운 객체 C'로 목적지 1회 변경
- 이벤트 45: A'의 B"가 조건C(Over, Under, Equl, Differ) D"'을 만족하면 가장 가까운 객체 E'로 목적지 변경
- 이벤트 46: A'가 FlagB""에 근접하면 로그C의 값을 D"'만큼 (증가/감소/대입)한다.
- 이벤트 47: A' B' 충돌시 로그C의 값을 D"'만큼 (증가/감소/대입)한다.
- 이벤트 48: A'의 B"가 조건C(Over, Under, Equl, Differ) D"'을 만족하면 로그E의 값을 F"'만큼 (증가/감소/대입)한다.


이벤트 시연 : [YouTubeLink](https://youtu.be/m4Wxte23GWw)
