# portfolio_Pacman

</br>

## 1. 플레이 방법
- 깃허브 내의 파일을 받아서 플레이 해보실 수 있습니다.

## 2. 제작 기간 & 참여 인원
- 2021년 3월 10일 ~ 7월 7일
- 개인 프로젝트

</br>

## 3. 사용 기술
  - c# Form

</br>

## 4. 트러블 슈팅
  - Ghost의 움직임이 기존Pacman게임의 등장하는 Ghost와 매우 유사한 AI를 가졌습니다.
  
  - 하지만 실시간으로 팩맨의 위치를 잡아가며 알고리즘을 계속 실행시키면 게임이 너무 무거워지는 현상이 생겨났습니다.

  - Ghost가 방향을 변경할 수 있는 교차로를 지나갈 때마다 알고리즘을 실행시켜 Ghost의 움직임을 초기화시켜주었습니다.
  
  - 알고리즘을 실행시키는 빈도수가 확 줄게 되면서 게임이 많이 가벼워졌습니다.

<details>
<summary><b>코드</b></summary>
<div markdown="1">

~~~java
/**
 * 게시물 필터 (Tag Name)
 */
private void blinkyAlgorithm(int x, int y, int cnt)
        {
            checkMap[y, x] = 01;
            if (x == pacmanX && y == pacmanY)
                return;
            while (checkMap[pacmanY, pacmanX] == 0)
            {
                for (int i = 0; i < 30; i++)
                    for (int j = 0; j < 27; j++)
                        if (checkMap[i, j] > 0) {
                            if (checkMap[i + 1, j] == 00)
                                checkMap[i + 1, j] = checkMap[i, j] + 1;
                            if (checkMap[i - 1, j] == 00)
                                checkMap[i - 1, j] = checkMap[i, j] + 1;
                            if (checkMap[i, j + 1] == 00)
                                checkMap[i, j + 1] = checkMap[i, j] + 1;
                            if (checkMap[i, j - 1] == 00)
                                checkMap[i, j - 1] = checkMap[i, j] + 1;
                        }
            }
            int X = pacmanX;
            int Y = pacmanY;
            while (true)
            {
                if (checkMap[Y + 1, X] == checkMap[Y, X] - 1)
                {
                    blinkyMoveRouteX.Insert(0, X);
                    blinkyMoveRouteY.Insert(0, Y);
                    Y += 1;
                    if (X == x && Y == y)
                        break;
                }
                if (checkMap[Y - 1, X] == checkMap[Y, X] - 1)
                {
                    blinkyMoveRouteX.Insert(0, X);
                    blinkyMoveRouteY.Insert(0, Y);
                    Y -= 1;
                    if (X == x && Y == y)
                        break;
                }
                if (checkMap[Y, X + 1] == checkMap[Y, X] - 1)
                {
                    blinkyMoveRouteX.Insert(0, X);
                    blinkyMoveRouteY.Insert(0, Y);
                    X += 1;
                    if (X == x && Y == y)
                        break;
                }
                if (checkMap[Y, X - 1] == checkMap[Y, X] - 1)
                {
                    blinkyMoveRouteX.Insert(0, X);
                    blinkyMoveRouteY.Insert(0, Y);
                    X -= 1;
                    if (X == x && Y == y)
                        break;
                }
            }
        }
~~~

</div>
</details>

## 5.그 외 오류들
  - 클라이드 유령의 움직임이 이상한 방향으로 움직일 때가 있음.
  
  
## 6.느낀점
- 각 유령의 움직임을 원본 게임과 최대한 비슷하게 하기 위하여 애를 먹은 것 같습니다. 하지만 결과물은 잘 나왔다고 생각되었고 후에 몬스터의 AI제작을 하게 될 경우 많은 도움이 될 것입니다.
