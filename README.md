SBS 게임 아카테미 주말반 팀 프로젝트
=============

프로젝트 소개
-------------


#### 1. 프로젝트 명칭 : (제목 미정)

#### 2. 프로젝트 기간
- **프로젝트 개발 기간 :** 2024년 7월 20일 ~ 2024년 8월 24일 매주 토요일(36시간)
- **프로젝트 개발 목적 :** "공장 자동화" 게임을 개발하여 플레이어가 다양한 공장을 관리하고 업그레이드하는 게임 메커니즘을 개발합니다. 이 과정에서 시장에 출시 가능한 게임 제작 경험을 제공합니다.

#### 3. 주요 개발 내용
- **게임 설계 :** 게임의 전반적인 구조와 메커닉 설계, 공장 및 자원 시스템을 포함한 게임 컨셉의 설정을 수행합니다.
- **기술 개발 :** Unity 엔진을 사용한 게임 개발, 공장 및 자원 생성 로직, 플레이어 인터랙션 처리 등을 포함합니다.
- **아트 및 사운드 :** 게임의 시각적 요소인 공장 및 배경 디자인, 사용자 인터페이스, 애니메이션 및 사운드 이펙트의 제작과 통합을 진행합니다.

#### 4. 사용 기술 및 도구
- **개발 플랫폼 :** Unity
- **버전 관리 :** Git, GitHub

#### 5 팀원 목록
- **1. 김준호** 
- **2. 서범규** 
- **3. 성동현** 
- **4. 오준식**

개발 일정 및 주차별 작업 내용
----------------
### 1주차 : 프로젝트 계획 및 기획
#### 주요 활동:
- **게임 아이디어 선정 및 목표 설정**
- **게임 디자인 문서 초안 작성**
- **팀원 역할 분담**
- **개발 도구 및 플랫폼 설정**

### 2주차: 초기 개발 환경 설정 및 기초 구현
- **김준호 학생**
    - **주요 작업 내용 :**
        **인벤토리 관리 시스템 구현 :** 아이템의 추가, 삭제 및 인벤토리 UI 업데이트 관리 
    - **세부사항 :** 
        - **Inventory.cs :** 아이템 관리와 UI 업데이트를 담당.
        - **ItemData.cs :** 아이템의 기본 속성 정의.
        - **UI_ItemSlot.cs :** 아이템 슬롯의 UI를 관리.
        - **UI_ItemTooltip.cs :** 아이템 상세 정보 표시를 관리.
        - **UI_ItemTooltip.cs :** UI 기능 실행 및 인벤토리 UI 토글 관리.
        - **특징:**
            - 싱글턴 패턴 사용으로 하나의 인벤토리 인스턴스 유지.
            - 이벤트 리스너를 통한 UI 상호작용 관리.
            - 데이터 일관성 확보를 위해 아이템 추가 및 삭제 시 리스트와 딕셔너리 모두 업데이트.
- **서범규 학생**
    - **주요 작업 내용 :** 
    - **세부사항 :** 
- **성동현 학생**
    - **주요 작업 내용 :**
    - **세부사항 :** 
- **오준식 학생**
    - **주요 작업 내용 :**
    - **세부사항 :** 

### 3주차: 핵심 기능 개발 및 프로토타입 제작
- **김준호 학생**
    - **주요 작업 내용 :**
        **저장 및 로드 시스템 개발 :** 게임 데이터의 저장 및 로드 기능 구현.
        **오디오 시스템 구현 :** 게임 내 음향 관리 및 사용자 인터페이스 조작 가능성 개선.
    - **세부사항 :** 
        - **Save and Load 시스템 :** 
            - **SerializableDictionary :** 직렬화 가능한 사용자 정의 클래스로, 데이터를 JSON 형식으로 관리.
            - **GameData :** 게임 데이터 관리.
            - **FileDataHandler :** 파일 입출력 관리.
            - **ISaveManager :** 데이터 저장 및 로딩 인터페이스.
            - **SaveManager :** 실제 게임 데이터 저장 및 로딩 실행.
        - **오디오 시스템 :** 
            - **AudioManager :** 오디오 소스 관리 및 효과음과 배경음악 재생.
            - **UI_VolumeSlider :** 볼륨 조절 가능한 슬라이더 UI.
- **서범규 학생**
    - **주요 작업 내용 :**
    - **세부사항 :** 
- **성동현 학생**
    - **주요 작업 내용 :**
    - **세부사항 :** 
- **오준식 학생**
    - **주요 작업 내용 :**
        - 랜덤 뽑기 구현
        - 옵션 UI 구현 중
    - **세부사항 :** 
        - **애니메이션 곡선으로 구현:** 랜덤 뽑기 및 옵션 UI에 자연스러운 애니메이션 효과를 곡선 애니메이션을 사용해서 구현

### 4주차: 게임 기능 확장 및 중간 점검
- **김준호 학생**
    - **주요 작업 내용 :**
        - 강화시스템 구현
        - 공장 배치 시스템 구현
        - 기타 버그 수정  
    - **세부사항 :** 
        - **강화 시스템:** 'ProbabilityUpgrade.cs', 'SpeedUpgrade.cs', 'UpgradeCost.cs'를 사용하여 확률과 골드생산 시간을 강화하는 시스템을 추가했습니다. 이 시스템은 골드를 소모하여 각 요소를 업그레이드하며, 강화 가능성과 비용은 csv 파일 데이터 테이블을 참조합니다.
        - **공장 배치 시스템:** 'Inventory.cs', 'UI_CurrentFactory.cs', 'UI_PopUpFactory.cs'를 통해 인벤토리에 있는 공장을 실제 게임 환경에 배치하는 시스템을 구현했습니다. 이 시스템은 UI와 긴밀하게 연동되어 플레이어가 손쉽게 공장을 배치할 수 있습니다.
        - **기타 버그 수정:** 개발 과정에서 발견된 여러 버그들을 수정하여 게임의 전반적인 안정성을 향상시켰습니다.
- **서범규 학생**
    - **주요 작업 내용 :**
    - **세부사항 :** 
- **성동현 학생**
    - **주요 작업 내용 :**
    - **세부사항 :** 
- **오준식 학생**
    - **주요 작업 내용 :**
    - **세부사항 :** 

### 5주차: 최종 기능 구현 및 폴리싱
- **김준호 학생**
    - **주요 작업 내용 :**
        - 재화 획득 시스템 구현
        - AI 생성 로직 추가
        - 기타 버그 수정  
    - **세부사항 :** 
        - **재화 획득 시스템:** 골드를 주기적으로 생성하는 시스템을 구현하여, SpeedUpgrade 클래스와 연동되어 골드 획득 속도를 관리합니다. 사용자 인터페이스로는 슬라이더를 통해 현재 속도를 시각적으로 표시하고, 골드 재화의 증가를 감시하는 역할을 합니다.
        - **AI 재화 생성 로직:** 게임 내 다양한 AI 로직을 관리하는 클래스를 추가하여, 각 공장의 동작 방식이나 행동 패턴을 독립적으로 설정할 수 있도록 구현했습니다.
- **서범규 학생**
    - **주요 작업 내용 :**
    - **세부사항 :** 
- **성동현 학생**
    - **주요 작업 내용 :**
    - **세부사항 :** 
- **오준식 학생**
    - **주요 작업 내용 :** 
        - 게임 소리 조절 기능 구현
    - **세부사항 :** 
        - **게임 소리 조절 인터페이스:** Unity의 UI 시스템인 캔버스를 활용하여, 게임 내 오디오 레벨을 사용자가 조절할 수 있는 슬라이더를 구현했습니다.