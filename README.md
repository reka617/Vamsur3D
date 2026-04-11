# 🧛 VamSur3D
![image alt](https://github.com/reka617/Vamsur3D/blob/7593e25c7333ba5c8493108e999fa6e33504d377/ProjectCover3.png)

> 2022년 유행이던  Vampire Survivors를 3D화해서 모작한 게임입니다.

<br>

## 📌 프로젝트 개요

| 항목 | 내용 |
|------|------|
| 장르 | 뱀서라이크|
| 플랫폼 | PC |
| 개발 기간 | 6개월 |
| 팀 구성 | 개발자 2인 |
| 담당 역할 | 로컬DB 및 몹, 플레이어 스텟관리 |

<br>

## ✨ 주요 기능

### 📂 JSON 기반 로컬 데이터 관리
> JSON 파싱을 통해 게임 데이터를 로컬에서 저장 및 불러옵니다.
> 플레이어 초기 스탯 및 무기 데이터를 JSON 포맷으로 관리합니다.

### 🧟 몬스터 AI 시스템
> FSM(유한 상태 머신) 기반으로 몬스터 행동 패턴을 구현했습니다.
> Object Pooling으로 몬스터 생성/제거 비용을 최소화하고,
> Factory Pattern으로 몬스터 종류별 생성을 관리합니다.

### ⚔️ 플레이어 / 무기 스탯 시스템
> JSON에서 플레이어 기본 스탯을 불러와 고정값으로 관리합니다.
> 인게임 수치 변화는 무기 강화에 따라 무기 스탯이 변경되는 방식으로 동작합니다.

<br>

## 📁 폴더 구조

```
📦 Assets
 ┣ 📂 Scripts
 ┃ ┣ 📂 Character        # 플레이어 캐릭터
 ┃ ┣ 📂 Controllers      # 카메라, 무기 컨트롤러
 ┃ ┣ 📂 DebugScripts     # 개발용 디버그 도구
 ┃ ┣ 📂 Managers         # DataManager, GameManager, UIManager
 ┃ ┣ 📂 Monster          # 몬스터 AI, 풀링, 상태관리
 ┃ ┣ 📂 SkillProjectiles # 스킬 및 투사체
 ┃ ┣ 📂 UI               # HUD, 메뉴, 팝업 UI
 ┃ ┣ 📂 Utils            # 싱글톤, 공용 유틸
 ┃ ┗ 📂 Weapons          # 무기 개별 구현체
 ┣ 📂 Terrains           # 지형 데이터
 ┣ 📂 _TerrainAutoUpgrade
 ┃
 ┣ 📂 3D Cartoon Village     # ※ Asset Store
 ┗ 📂 RPGMonsterBuddiesPBRPA # ※ Asset Store


> ※ 외부 에셋은 레포에 포함되지 않습니다.  
> Unity Asset Store에서 직접 임포트 후 사용해주세요.

```
<br>

## 🌿 브랜치 전략

| 브랜치 | 설명 |
|--------|------|
| `main` | 통합 브랜치 |
| `SJ` | 성준 작업 브랜치 |
| `XX` | 팀원 작업 브랜치 |

### 규칙
- 각자 본인 브랜치에서 작업
- 작업 완료 후 `main`으로 PR

<br>

## 📝 커밋 메시지

| Prefix | 용도 |
|--------|------|
| `[add]` | 새 파일, 기능 추가 |
| `[update]` | 기존 기능 개선 및 수정 |
| `[fix]` | 버그 수정 |
| `[edit]` | 오탈자, 주석, 문서 등 소규모 수정 |

<br>

## 🛠 기술 스택

| 분류 | 사용 기술 |
|------|-----------|
| 엔진 | ![Unity](https://img.shields.io/badge/Unity_2021.3-000000?style=for-the-badge&logo=unity&logoColor=white) |
| 언어 | ![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=sharp&logoColor=white) |
| DB | ![JSON](https://img.shields.io/badge/JSON-000000?style=for-the-badge&logo=JSON&logoColor=white) |
