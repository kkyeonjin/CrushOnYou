using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptManager
{
    public static Dictionary<string, List<string>> ScriptsInfo1 = new Dictionary<string, List<string>>(){

        {"True운동", new List<string>(){"응, 나 운동하는 거 좋아해.", "그치, 운동 하고 나면 엄청 상쾌하지 않아?", "(대화가 즐거웠습니다. 친밀도가 상승합니다.)"}},
        {"False운동", new List<string>(){"음, 난 운동하는 거 별로 좋아하지 않아", "땀 나고 숨 차는 거 딱 질색이야", "(더 이상 이어나갈 이야기가 없습니다. 친밀도가 하락합니다.)"}},

        {"True필름 카메라", new List<string>(){"와, 필름 카메라 너도 있어?", "맞아, 필름 카메라만의 맛이 있지.", "(공감대가 형성되었습니다. 친밀도가 상승합니다.)"}},
        {"False필름 카메라", new List<string>(){"필름 카메라?", "오, 멋지다.", "(별로 할 이야기가 없습니다. 친밀도가 하락합니다.)"}},

        {"True클래식 음악", new List<string>(){"클래식을 들으면 마음이 정말 편해져.", "너도 그래?", "(함께 대화하는 것도 편안하게 느껴집니다. 친밀도가 상승합니다.)"}},
        {"False클래식 음악",new List<string>(){"와, 너 클래식도 듣는구나.", "내가 클래식에 관해서는 문외한이라서...", "(대화가 끊겼습니다. 친밀도가 하락합니다.)"}},

        {"True인디 음악", new List<string>(){"누구 노래 듣고 있냐고?", "너도 이 가수 알아? 이 노래 아는 사람 별로 없던데.. 다음에 나랑도 같이 보러 가자.", "(같은 가수를 좋아한다는 것이 내심 좋은 것 같습니다. 친밀도가 상승합니다.)"}},
        {"False인디 음악", new List<string>(){"어? 누구 노래라고?", "아, 그렇구나... (잘 이해되지 않는 듯한 표정을 짓는다.)", "(상대는 이 주제에 관해 별로 관심이 없는 것 같습니다. 친밀도가 하락합니다..)"}},

        {"True드라마", new List<string>(){"오! 너 요즘 드라마 어떤 거 보는데?", "나도 그거 보는데! 그거 정말 재밌지 않아? 이번 8화에서 ... ", "(대화가 활발히 이루어졌습니다. 친밀도가 상승합니다.)"}},
        {"False드라마", new List<string>(){"내가 드라마를 잘 안 봐서. ", "아.. 그래? 알았어, 다음에 한번 볼게.", "(내가 추천한 드라마를 볼 생각이 없어 보입니다. 친밀도가 하락합니다..)"}},

        {"True노래방", new List<string>(){"노래방 좋아하냐고? 당연하지!", "의외다. 너는 노래방 같은 곳 안 좋아할 줄 알았는데.. 말 나온 김에 오늘 갈래?", "(상대의 기분이 좋아 보입니다. 친밀도가 상승합니다.)"}},
        {"False노래방", new List<string>(){"음.. 나는 노래방 한 번도 안 가봤어.", "별로 가고 싶지 않던데.", "(대화가 끊깁니다. 친밀도가 하락합니다.)"}},

        {"True별 보기", new List<string>(){"요즘 미세먼지가 많이 없어서 별도 잘 보이는 것 같아.", "그렇지 않아?", "(별자리에 관해 이야기합니다. 친밀도가 상승합니다.)"}},
        {"False별 보기", new List<string>(){"별?", "가끔씩 길 가다가 보긴 했어.", "(상대는 딱히 할 말이 없어보입니다. 친밀도가 하락합니다.)"}},

        {"True영화 감상", new List<string>(){"이번에 개봉한 영화 봤어?", "너도 그거 보고싶었다고? 같이 보러 갈래?", "(대화가 재미있게 이어집니다. 친밀도가 상승합니다.)"}},
        {"False영화 감상", new List<string>(){"최근에 본 영화? 영화관을 안 간지 오래돼서...", "잘 모르겠어", "(대화가 끊깁니다. 친밀도가 하락합니다.)"}},

        {"True산책", new List<string>(){"산책 좋아하지. 난 가끔 버스 안 타고 집으로 걸어가기도 해.", "너는 어디 살아? 나랑 같이 걸어가자.", "왠지 더욱 친해진 것 같습니다. 친밀도가 상승합니다."}},
        {"False산책", new List<string>(){"노래방 선택했을 때", "부정이", "친밀도 하락"}},

        {"True스포츠 경기 직관", new List<string>(){"너 야구 좋아해?", "어느 팀 응원해?", "(상대의 눈이 반짝입니다. 친밀도가 상승합니다.)"}},
        {"False스포츠 경기 직관", new List<string>(){"한 번도 경기장에 가서 직관한 적은 없는 것 같은데..", "아, 그래?", "상대는 관심이 없어 보입니다. 친밀도가 하락합니다."}},

        {"True게임", new List<string>(){"너 게임도 하는구나.", "무슨 게임 해?", "(서로 좋아하는 게임에 대해 이야기합니다. 친밀도가 상승합니다.)"}},
        {"False게임", new List<string>(){"게임은 잘 안해. 어려워서..", "오, 그렇구나", "(대화가 이어지지 않습니다. 친밀도가 하락합니다.)"}},

        {"True요리", new List<string>(){"나 요리하는거 진짜 좋아해.", "집에서 이것저것 해먹으려고 연습하다 보니 재밌어지더라고.", "(자신이 잘하는 요리에 관해 이야기합니다. 친밀도가 상승합니다.)"}},
        {"False요리", new List<string>(){"할 줄 아는 요리가 없어서...", "거의 라면밖에 못 끊이는 것 같은데.", "(상대가 조금 민망해합니다. 친밀도가 하락합니다.)"}},

        {"True환경문제", new List<string>(){"요즘에 텀블러 챙겨다니고 있어.", "종이컵이 아까워서... 너도 그래?", "(당신을 바라보는 눈빛이 달라지는 것 같습니다. 친밀도가 상승합니다.)"}},
        {"False환경문제", new List<string>(){"맞아, 환경 문제 심각하지.", "아껴 써야 하는데...", "(상대는 별로 관심이 없어 보입니다. 친밀도가 하락합니다.)"}},
        
        {"True경제", new List<string>(){"어제 뉴스 봤어?", "이제 정책이 바뀐다던데...", "(상대는 당신과 말이 잘 통한다고 느끼는 것 같습니다. 친밀도가 상승합니다.)"}},
        {"False경제", new List<string>(){"주식 한다고?", "대단하다…", "(상대는 신기해하지만, 관심은 없어 보입니다. 친밀도가 하락합니다.)"}},

        {"True연예인", new List<string>(){"너 이 그룹 어제 컴백한 거 봤어?", "난 나오자마자 봤지. 이번 무대 진짜 잘하지 않아?", "(즐거운 대화가 이어집니다. 친밀도가 상승합니다.)"}},
        {"False연예인", new List<string>(){"누가 그랬다고?", "미안, 내가 연예인은 잘 몰라서. ", "(상대는 이 주제에 관심이 없어 보입니다. 친밀도가 하락합니다.)"}},

        {"True베스트셀러", new List<string>(){"응? 나 신청했던 책 도착해서 도서관 가보려고!", "너도 같이 가자. ", "(함께 도서관으로 향합니다. 친밀도가 상승합니다.)"}},
        {"False베스트셀러", new List<string>(){"뭘 읽어봤냐고?", "음… 처음 들어보는데…", "(상대는 당신에게 거리감을 느낍니다. 친밀도가 하락합니다.)"}},

        {"True패션 트렌드", new List<string>(){"신발 예쁘다고? 고마워.", "너도 이런 거 관심 많구나.", "(상대와 더욱 가까워진 느낌입니다. 친밀도가 상승합니다.)"}},
        {"False패션 트렌드", new List<string>(){"이거 어디에서 산 거냐고?", "잘 기억이 안 나네…", "(대화가 이어지지 않습니다. 친밀도가 하락합니다.)"}},

        {"TrueSNS", new List<string>(){"너도 인스타 해? 우와", "나도 너 인스타 아이디 알려줄래?", "(인스타 맞팔이 되었습니다. 친밀도가 상승합니다.)"}},
        {"FalseSNS", new List<string>(){"난 sns 잘 안 해서.. 계정이 없어. ", "음… 아쉽네. ", "(상대는 정말 관심 없어 보입니다. 친밀도가 하락합니다.)"}},

        {"True학교 수업", new List<string>(){"오늘 필기 놓쳤다고?", "내 필기 보여줄게, 자. ", "(상대가 뿌듯해합니다. 친밀도가 상승합니다.)"}},
        {"False학교 수업", new List<string>(){"오늘 필기한 내용?", "미안, 나도 잘 못 들었어...", "(상대가 말끝을 흐립니다. 친밀도가 하락합니다.)"}},

        {"True수행평가", new List<string>(){"어제 수행평가 준비하느라 밤 샜어…", "맞아, 준비 진짜 열심히 했지. 너는? ", "(상대는 당신과 말이 잘 통한다고 느끼는 것 같습니다. 친밀도가 상승합니다.)"}},
        {"False수행평가", new List<string>(){"수행평가 준비했냐고?", "음... 그냥 조금?", "(상대가 말끝을 흐립니다. 친밀도가 하락합니다.)"}},

        {"True시험공부", new List<string>(){"시험범위 어떤 거?", "아, 그거 내가 알려줄게. 나도 어려운 줄 알았는데 생각보다 할 만 하더라고. ", "(상대는 당신을 돕는 것에 보람을 느끼는 것 같습니다. 친밀도가 상승합니다.)"}},
        {"False시험공부", new List<string>(){"아.. 난 이번 시험공부 하나도 못했어...", "너는?", "(상대는 좀 풀죽어 보입니다. 친밀도가 하락합니다.)"}},

        {"True급식", new List<string>(){"오늘 급식 뭐지? 너무 배고파.", "아 오늘 수요일이지! 다 먹어주겠어.", "(상대는 기분이 좋아 보입니다. 친밀도가 상승합니다.)"}},
        {"False급식", new List<string>(){"오늘 급식 뭐냐고?", "글쎄?", "(대화가 이어지지 않습니다. 친밀도가 하락합니다.)"}},

        {"True점심시간", new List<string>(){"나 점심시간에 산책 좀 하고 오려고.", "너도 같이 갈래?", "(상대와 산책을 다녀옵니다. 친밀도가 상승합니다.)"}},
        {"False점심시간", new List<string>(){"점심시간에 뭐 할거냐고?", "그냥 교실에 앉아서 쉴래..", "(상대는 혼자만의 시간을 즐기고 싶어합니다. 친밀도가 하락합니다.)"}},

        {"True선생님", new List<string>(){"난 이 선생님이 제일 좋더라. ", "너는?", "(상대와 함께 선생님에 대해 이야기를 나눕니다. 친밀도가 상승합니다.)"}},
        {"False선생님", new List<string>(){"난 그 선생님 좀 무서워..", "저번에도 조금 혼났어.", "(기분이 좋지 않아 보입니다. 친밀도가 하락합니다.)"}},

        {"True어젯밤 꿈", new List<string>(){"나도 어제 꿈 꿨다!", "무슨 꿈이냐고? 비밀이야.", "(상대는 기분이 좋아 보입니다. 친밀도가 상승합니다.)"}},
        {"False어젯밤 꿈", new List<string>(){"어제 꿈 꿨다고?", "...그런 꿈을 꿨구나.", "(별로 할 말이 없어 보입니다. 친밀도가 하락합니다.)"}},

        {"True맛집", new List<string>(){"와, 이번에 학교 앞에 생긴 곳 진짜 맛있더라.", "오늘 야자 째고 먹으러 갈래? ", "(대화가 즐겁습니다. 친밀도가 상승합니다.)"}},
        {"False맛집", new List<string>(){"아, 그래? 거기가 어딘데?", "그렇구나. ", "(아마 상대는 당신이 추천한 맛집에 가보지 않을 것 같습니다. 친밀도가 하락합니다.)"}},

        {"True반려동물", new List<string>(){"너 고양이 키워? 너무 귀엽겠다...", "나 사진 좀 보여줘. 이름이 뭔데?", "(고양이가 세상을 구합니다. 친밀도가 상승합니다.)"}},
        {"False반려동물", new List<string>(){"아. 나 털 알레르기 있어서..", "그리고 보통 날 안 좋아하는 것 같더라고..", "(대화가 끊깁니다. 친밀도가 하락합니다.)"}},

        {"True플레이리스트", new List<string>(){"너 이거 들어볼래?", "유튜브 알고리즘으로 알게 된 노래인데 요즘에 이것만 돌려 들어. ", "(상대의 눈이 반짝입니다. 친밀도가 상승합니다.)"}},
        {"False플레이리스트", new List<string>(){"무슨 노래 듣고 있냐고?", "...사실 아무것도 안 듣고 있어. ", "(대화가 이어지지 않습니다. 친밀도가 하락합니다.)"}},

        {"True위시리스트", new List<string>(){"나도 사고 싶은 거 생겼어.", "요즘 돈을 너무 많이 쓴 것 같은데... 살까 말까?", "(상대의 위시리스트를 구경했습니다. 친밀도가 상승합니다.)"}},
        {"False위시리스트", new List<string>(){"요즘 사고 싶은 거? 딱히 없어.", "음 그러게... 생각해 본 적이 없는 거 같아.", "(상대는 별로 관심이 없어 보입니다. 친밀도가 하락합니다.)"}},

        {"TrueTMI", new List<string>(){"이건 진짜 TMI인데.. ", "나 오늘 학교 오는 길에 너 봤다.", "(상대가 미소짓고 있습니다. 친밀도가 상승합니다.)"}},
        {"FalseTMI", new List<string>(){"뭐라고?", "아아.", "(상대는 당신의 TMI가 궁금하지 않은 것 같습니다. 친밀도가 하락합니다.)"}},

    };

    public static Dictionary<string, List<string>> ScriptsInfo2 = new Dictionary<string, List<string>>(){

        {"tt운동", new List<string>(){"나 요즘 운동 시작했어.", "오! 나도 관심있는데. 어떤 운동 해?", "(분위기가 좋아보입니다. 모두에 대한 친밀도가 상승합니다.)"}},
        {"ff운동", new List<string>(){"운동? 난 운동은 잘 못해서...", "나도 운동은 별로 안좋아해.", "(두 사람이 공감대를 형성합니다. 서로에 대한 친밀도가 상승합니다.)"}},
        {"tf운동", new List<string>(){"나 운동하는 거 정말 좋아하는데! 넌 어때?", "아아.. 난 운동 잘 못하기도 하고 별로 좋아하진 않아.", "(대화거리가 더 이상 없어보입니다. 서로에 대한 친밀도가 하락합니다.)"}},

        {"tt필름 카메라", new List<string>(){"와, 필름 카메라 너도 있어?", "응, 나도 도전해보고 싶어서 저번에 샀어.", "(분위기가 좋아보입니다. 모두에 대한 친밀도가 상승합니다.)"}},
        {"ff필름 카메라", new List<string>(){"흠.. 나 필름 카메라는 한 번도 안 써봤어.", "필름 갈아끼우고 관리하는 거 너무 어렵지 않아?", "(두 사람이 공감대를 형성합니다. 서로에 대한 친밀도가 상승합니다.)"}},
        {"tf필름 카메라", new List<string>(){"필름 카메라 다들 한번 써봐. 분위기가 진짜 달라.", "오.. 그렇구나.", "(대화거리가 더 이상 없어보입니다. 서로에 대한 친밀도가 하락합니다.)"}},

        {"tt클래식 음악", new List<string>(){"클래식 음악을 들으면 마음이 편해져.", "나도 그래. 어떤 곡 제일 좋아해?", "(분위기가 좋아보입니다. 모두에 대한 친밀도가 상승합니다.)"}},
        {"ff클래식 음악", new List<string>(){"내가 클래식 음악은 잘 몰라서...", "나도 아는 게 많이 없어.", "(두 사람이 공감대를 형성합니다. 서로에 대한 친밀도가 상승합니다.)"}},
        {"tf클래식 음악", new List<string>(){"클래식 음악을 들으면 마음이 편해져.", "아 그래? 그렇구나...", "(대화거리가 더 이상 없어보입니다. 서로에 대한 친밀도가 하락합니다.)"}},

        {"tt인디 음악", new List<string>(){"너 이 가수 아는구나!", "당연하지. 노래 정말 좋지 않아?", "(분위기가 좋아보입니다. 모두에 대한 친밀도가 상승합니다.)"}},
        {"ff인디 음악", new List<string>(){"인디 밴드 잘 모르는데..", "나도 많이 듣진 않는 것 같아.", "(두 사람이 공감대를 형성합니다. 서로에 대한 친밀도가 상승합니다.)"}},
        {"tf인디 음악", new List<string>(){"너 혹시 이 가수 알아?", "어... 이게 누군데?", "(대화거리가 더 이상 없어보입니다. 서로에 대한 친밀도가 하락합니다.)"}},

        {"tt드라마", new List<string>(){"너 요즘 그거 봐?", "와, 그거 진짜 재밌더라. 이번 화 어떻게 생각해?", "(분위기가 좋아보입니다. 모두에 대한 친밀도가 상승합니다.)"}},
        {"ff드라마", new List<string>(){"난 드라마 잘 안 봐서.", "앗, 나도.", "(두 사람이 공감대를 형성합니다. 서로에 대한 친밀도가 상승합니다.)"}},
        {"tf드라마", new List<string>(){"나 요즘 이 드라마 봐!", "아... 그래?", "(대화거리가 더 이상 없어보입니다. 서로에 대한 친밀도가 하락합니다.)"}},

        {"tt노래방", new List<string>(){"오늘 뭔가 노래방 가고 싶지 않아?", "아, 그럴 때 바로 가야지. 같이 가자!", "(분위기가 좋아보입니다. 모두에 대한 친밀도가 상승합니다.)"}},
        {"ff노래방", new List<string>(){"노래방 별로 안 좋아해.", "나도... 시끄럽고 불편하고 그렇더라고.", "(두 사람이 공감대를 형성합니다. 서로에 대한 친밀도가 상승합니다.)"}},
        {"tf노래방", new List<string>(){"오늘 뭔가 노래방 가고 싶지 않아?", "난 빼줘...", "(대화거리가 더 이상 없어보입니다. 서로에 대한 친밀도가 하락합니다.)"}},

        {"tt별 보기", new List<string>(){"요즘 미세먼지가 많이 없어서 별도 잘 보이는 것 같아.", "맞아. 별 보러 다니기 딱 좋은 날씨더라.", "(분위기가 좋아보입니다. 모두에 대한 친밀도가 상승합니다.)"}},
        {"ff별 보기", new List<string>(){"최근에 별을 본 기억은 없는 것 같은데.", "아마 공기가 안 좋아서 잘 안 보일걸.", "(두 사람이 공감대를 형성합니다. 서로에 대한 친밀도가 상승합니다.)"}},
        {"tf별 보기", new List<string>(){"요즘 미세먼지가 많이 없어서 별도 잘 보이는 것 같아.", "음.. 그렇구나.", "(대화거리가 더 이상 없어보입니다. 서로에 대한 친밀도가 하락합니다.)"}},
        
        {"tt영화 감상", new List<string>(){"이번에 개봉한 영화 봤어?", "난 벌써 n번 봤어... 다음에 또 보러 갈거야.", "(분위기가 좋아보입니다. 모두에 대한 친밀도가 상승합니다.)"}},
        {"ff영화 감상", new List<string>(){"최근에 본 영화? 영화관을 안 간지 오래돼서...", "그러게. 나도 요즘 영화는 본 게 없네.", "(두 사람이 공감대를 형성합니다. 서로에 대한 친밀도가 상승합니다.)"}},
        {"tf영화 감상", new List<string>(){"이번에 개봉한 영화 봤어?", "음 아니... 영화 안 본지 좀 된 거 같아.", "(대화거리가 더 이상 없어보입니다. 서로에 대한 친밀도가 하락합니다.)"}},
        
        {"tt산책", new List<string>(){"오늘 날씨 진짜 좋다. 산책하기 딱 좋은데?", "맞아. 산책 다들 좋아하는구나.", "(분위기가 좋아보입니다. 모두에 대한 친밀도가 상승합니다.)"}},
        {"ff산책", new List<string>(){"산책하는 거 난 별로 좋아하진 않아.", "나도... 시간도 별로 없고 쉽지 않더라고.", "(두 사람이 공감대를 형성합니다. 서로에 대한 친밀도가 상승합니다.)"}},
        {"tf산책", new List<string>(){"오늘 날씨 진짜 좋다. 산책하기 딱 좋은데?", "음...", "(대화거리가 더 이상 없어보입니다. 서로에 대한 친밀도가 하락합니다.)"}},
        
        {"tt스포츠 경기 직관", new List<string>(){"와, 너 야구 좋아해? ", "진짜 좋아해. 너 어느 팀 응원하는데?", "(분위기가 좋아보입니다. 모두에 대한 친밀도가 상승합니다.)"}},
        {"ff스포츠 경기 직관", new List<string>(){"음... 경기 직접 보러 간 적은 한 번도 없는 것 같은데?", "나도. 나는 룰을 잘 몰라서.", "(두 사람이 공감대를 형성합니다. 서로에 대한 친밀도가 상승합니다.)"}},
        {"tf스포츠 경기 직관", new List<string>(){"너 경기 직관하러 가본 적 있어?", "난 한 번도 없는 것 같아.", "(대화거리가 더 이상 없어보입니다. 서로에 대한 친밀도가 하락합니다.)"}},
        
        {"tt게임", new List<string>(){"게임 좋아해? ", "나 진짜 많이 해. 너는 어떤 게임 하는데?", "(분위기가 좋아보입니다. 모두에 대한 친밀도가 상승합니다.)"}},
        {"ff게임", new List<string>(){"게임은 잘 안해. 어려워서..", "나도 잘 못해서 안하게 되더라.", "(두 사람이 공감대를 형성합니다. 서로에 대한 친밀도가 상승합니다.)"}},
        {"tf게임", new List<string>(){"게임 좋아해?", "아... 난 게임을 잘 하진 않아.", "(대화거리가 더 이상 없어보입니다. 서로에 대한 친밀도가 하락합니다.)"}},
        
        {"tt요리", new List<string>(){"다들 요리하는 거 좋아해? 난 요즘 뭐 만들어먹는 게 가장 재밌더라.", "오, 나도! 요리 해먹는 게 삶의 낙이야.", "(분위기가 좋아보입니다. 모두에 대한 친밀도가 상승합니다.)"}},
        {"ff요리", new List<string>(){"할 줄 아는 요리가 없어서...", "나도 요리는 자신이 없어.", "(두 사람이 공감대를 형성합니다. 서로에 대한 친밀도가 상승합니다.)"}},
        {"tf요리", new List<string>(){"다들 요리하는 거 좋아해? 난 요즘 뭐 만들어먹는 게 가장 재밌더라.", "오 그렇구나. 나는 요리에 소질이 없어서...", "(대화거리가 더 이상 없어보입니다. 서로에 대한 친밀도가 하락합니다.)"}},
        
        {"tt환경문제", new List<string>(){"응, 나 요즘 종이컵 아까워서 텀블러 들고 다녀. ", "와, 너 멋지다. 나도 조금씩 실천하려고 노력 중이야. ", "(분위기가 좋아보입니다. 모두에 대한 친밀도가 상승합니다.)"}},
        {"ff환경문제", new List<string>(){"맞아… 뭐든 아껴써야 맞긴 하지. ", "그러게. ", "(두 사람이 공감대를 형성합니다. 서로에 대한 친밀도가 상승합니다.)"}},
        {"tf환경문제", new List<string>(){"응, 요즘 텀블러 가지고 다니고 있어. 환경 생각해야지. ", "오, 그렇구나. ", "(대화거리가 더 이상 없어보입니다. 서로에 대한 친밀도가 하락합니다.)"}},
        
        {"tt경제", new List<string>(){"맞아, 나 용돈 조금으로 주식 투자해보고 있어. ", "오! 어디에 투자했는데?", "(분위기가 좋아보입니다. 모두에 대한 친밀도가 상승합니다.)"}},
        {"ff경제", new List<string>(){"정책이 바뀐다고? 그렇구나..", "난 그런거 어렵고 잘 모르겠더라. ", "(두 사람이 공감대를 형성합니다. 서로에 대한 친밀도가 상승합니다.)"}},
        {"tf경제", new List<string>(){"맞아, 나 용돈 조금으로 주식 투자해보고 있어. ", "오… 신기하다. ", "(대화거리가 더 이상 없어보입니다. 서로에 대한 친밀도가 하락합니다.)"}},
        
        {"tt연예인", new List<string>(){"너 이 그룹 어제 컴백한 거 봤어?", "당연히 봤지. 수록곡도 좋은 곡 진짜 많더라.", "(분위기가 좋아보입니다. 모두에 대한 친밀도가 상승합니다.)"}},
        {"ff연예인", new List<string>(){"어제 그런 일이 있었다고..? 미안, 내가 연예인은 잘 몰라. ", "나도… 잘 모르겠네. ", "(두 사람이 공감대를 형성합니다. 서로에 대한 친밀도가 상승합니다.)"}},
        {"tf연예인", new List<string>(){"너 이 그룹 어제 컴백한 거 봤어?", "...이게 누군데?", "(대화거리가 더 이상 없어보입니다. 서로에 대한 친밀도가 하락합니다.)"}},

        {"tt베스트셀러", new List<string>(){"나 신청했던 책 도착해서 도서관 가보려고 하는데. 같이 갈래?", "와! 무슨 책 신청했어? 나도 같이 갈래.", "(분위기가 좋아보입니다. 모두에 대한 친밀도가 상승합니다.)"}},
        {"ff베스트셀러", new List<string>(){"요즘에 책 읽는 거 있냐고? 하하...", "바빠서 독서할 시간도 없어.", "(두 사람이 공감대를 형성합니다. 서로에 대한 친밀도가 상승합니다.)"}},
        {"tf베스트셀러", new List<string>(){"나 신청했던 책 도착해서 도서관 가보려고 하는데. 같이 갈래?", "음, 아니.", "(대화거리가 더 이상 없어보입니다. 서로에 대한 친밀도가 하락합니다.)"}},

        {"tt패션 트렌드", new List<string>(){"앗, 신발 예쁘다고? 고마워. ", "진짜로. 이거 어디서 샀어?", "(분위기가 좋아보입니다. 모두에 대한 친밀도가 상승합니다.)"}},
        {"ff패션 트렌드", new List<string>(){"옷 어디서 사냐고? 그냥 집에 있는거 입는데…", "맞아, 나도. ", "(두 사람이 공감대를 형성합니다. 서로에 대한 친밀도가 상승합니다.)"}},
        {"tf패션 트렌드", new List<string>(){"오, 너 신발 예쁘다. 어디서 산 거야?", "어 글쎄… 잘 기억이 안 나. ", "(대화거리가 더 이상 없어보입니다. 서로에 대한 친밀도가 하락합니다.)"}},

        {"ttSNS", new List<string>(){"너 인스타 해?", "응! 우리 아이디 공유하자.", "(분위기가 좋아보입니다. 모두에 대한 친밀도가 상승합니다.)"}},
        {"ffSNS", new List<string>(){"인스타? 난 sns 잘 안 해서.. 계정이 없어. ", "음... 나도.", "(두 사람이 공감대를 형성합니다. 서로에 대한 친밀도가 상승합니다.)"}},
        {"tfSNS", new List<string>(){"너 인스타 해? 나랑 맞팔하자.", "아... 미안. 내가 계정이 없어서.", "(대화거리가 더 이상 없어보입니다. 서로에 대한 친밀도가 하락합니다.)"}},

        {"tt학교 수업", new List<string>(){"오늘 이 부분 필기 놓쳤는데 혹시 너 적었어?", "응! 적어놨어. 여기 있어.", "(분위기가 좋아보입니다. 모두에 대한 친밀도가 상승합니다.)"}},
        {"ff학교 수업", new List<string>(){"오늘 수업 필기? 미안.. 나 많이 못 해놨는데. ", "앗…나도.", "(두 사람이 공감대를 형성합니다. 서로에 대한 친밀도가 상승합니다.)"}},
        {"tf학교 수업", new List<string>(){"오늘 이 부분 필기 놓쳤는데 혹시 너 적었어?", "앗 미안... 나도 이 부분 잘 못 들었어.", "(대화거리가 더 이상 없어보입니다. 서로에 대한 친밀도가 하락합니다.)"}},
        
        {"tt수행평가", new List<string>(){"오늘 수행평가 준비 잘 했어?", "응, 이번에 진짜 열심히 했어.", "(분위기가 좋아보입니다. 모두에 대한 친밀도가 상승합니다.)"}},
        {"ff수행평가", new List<string>(){"어? 오늘 수행평가였어?", "아, 나도 까먹었다. ", "(두 사람이 공감대를 형성합니다. 서로에 대한 친밀도가 상승합니다.)"}},
        {"tf수행평가", new List<string>(){"오늘 수행평가 준비 잘 했어?", "아 맞다, 오늘 수행평가 있었지?!", "(대화거리가 더 이상 없어보입니다. 서로에 대한 친밀도가 하락합니다.)"}},
        
        {"tt시험공부", new List<string>(){"너희 이번 시험 범위 중에 이 부분 괜찮았어?", "아, 이거 나도 어려울 줄 알았는데 이렇게 하면 쉽더라. 내가 알려줄게. ", "(분위기가 좋아보입니다. 모두에 대한 친밀도가 상승합니다.)"}},
        {"ff시험공부", new List<string>(){"시험 공부 많이 했냐고? 하하…", "그런 건 물어보는 거 아니야. ", "(두 사람이 공감대를 형성합니다. 서로에 대한 친밀도가 상승합니다.)"}},
        {"tf시험공부", new List<string>(){"시험공부 많이 했어?", "아.. 난 이번 시험공부 하나도 못했어...", "(대화거리가 더 이상 없어보입니다. 서로에 대한 친밀도가 하락합니다.)"}},

        {"tt급식", new List<string>(){"오늘 급식 뭐지? 너무 배고파.", "오늘 소세지야채볶음 나오는 날이잖아. 내가 다 먹을 거야.", "(분위기가 좋아보입니다. 모두에 대한 친밀도가 상승합니다.)"}},
        {"ff급식", new List<string>(){"오늘 급식 뭐냐고? 글쎄...", "부정: 교실 앞에 붙어있지 않을까?", "(두 사람이 공감대를 형성합니다. 서로에 대한 친밀도가 상승합니다.)"}},
        {"tf급식", new List<string>(){"오늘 급식 뭐지? 너무 배고파.", "뭐였더라...", "(대화거리가 더 이상 없어보입니다. 서로에 대한 친밀도가 하락합니다.)"}},

        {"tt점심시간", new List<string>(){"나 점심시간에 산책 좀 하고 오려고. 너희도 같이 갈래?", "그래! 같이 가자.", "(분위기가 좋아보입니다. 모두에 대한 친밀도가 상승합니다.)"}},
        {"ff점심시간", new List<string>(){"점심시간에 뭐 할거냐고? 별 계획 없었는데..", "나도 그냥 교실에서 쉬려고.", "(두 사람이 공감대를 형성합니다. 서로에 대한 친밀도가 상승합니다.)"}},
        {"tf점심시간", new List<string>(){"나 점심시간에 산책 좀 하고 오려고. 너희도 같이 갈래?", "아니.. 난 교실에서 쉴래.", "(대화거리가 더 이상 없어보입니다. 서로에 대한 친밀도가 하락합니다.)"}},

        {"tt선생님", new List<string>(){"아, 난 이 선생님이 제일 좋은 것 같아. ", "나도. 애들 말도 잘 들어주시고 최고야. ", "(분위기가 좋아보입니다. 모두에 대한 친밀도가 상승합니다.)"}},
        {"ff선생님", new List<string>(){"아 또 선생님께 혼났어…", "그 선생님이 원래 좀 무서우신 것 같아. ", "(두 사람이 공감대를 형성합니다. 서로에 대한 친밀도가 상승합니다.)"}},
        {"tf선생님", new List<string>(){"아, 난 이 선생님이 제일 좋은 것 같아. ", "그래? 난 제일 무섭던데…", "(대화거리가 더 이상 없어보입니다. 서로에 대한 친밀도가 하락합니다.)"}},

        {"tt어젯밤 꿈", new List<string>(){"야, 나 어제 신기한 꿈 꿨다. ", "오오, 무슨 꿈이었는데?", "(분위기가 좋아보입니다. 모두에 대한 친밀도가 상승합니다.)"}},
        {"ff어젯밤 꿈", new List<string>(){"꿈을 꿨다고? 오오…", "신기한 꿈을 꿨네. ", "(두 사람이 공감대를 형성합니다. 서로에 대한 친밀도가 상승합니다.)"}},
        {"tf어젯밤 꿈", new List<string>(){"야, 나 어제 신기한 꿈 꿨다. ", "음.. 그래?", "(대화거리가 더 이상 없어보입니다. 서로에 대한 친밀도가 하락합니다.)"}},
        
        {"tt맛집", new List<string>(){"와, 이번에 학교 앞에 생긴 곳 진짜 맛있더라.", "나 거기 가보고 싶었는데!", "(분위기가 좋아보입니다. 모두에 대한 친밀도가 상승합니다.)"}},
        {"ff맛집", new List<string>(){"맛집이 생겼다고? 음…", "난 굳이 가보고 싶진 않아. ", "(두 사람이 공감대를 형성합니다. 서로에 대한 친밀도가 상승합니다.)"}},
        {"tf맛집", new List<string>(){"와, 이번에 학교 앞에 생긴 곳 진짜 맛있더라.", "오, 그렇구나.", "(대화거리가 더 이상 없어보입니다. 서로에 대한 친밀도가 하락합니다.)"}},
        
        {"tt반려동물", new List<string>(){"와, 너 고양이 키워? 엄청 귀엽겠다!", "나 사진 보여줘. 진짜 이쁘겠다. ", "(분위기가 좋아보입니다. 모두에 대한 친밀도가 상승합니다.)"}},
        {"ff반려동물", new List<string>(){"아. 나 털 알레르기 있어서..", "난 동물 좀 무서워해..", "(두 사람이 공감대를 형성합니다. 서로에 대한 친밀도가 상승합니다.)"}},
        {"tf반려동물", new List<string>(){"너 고양이 키워? 엄청 귀엽겠다!", "오… 그러게. ", "(대화거리가 더 이상 없어보입니다. 서로에 대한 친밀도가 하락합니다.)"}},

        {"tt플레이리스트", new List<string>(){"너희 요즘 무슨 노래 들어? 난 이거 좋던데.", "오, 이 노래 진짜 좋다. 이거 신곡이야?", "(분위기가 좋아보입니다. 모두에 대한 친밀도가 상승합니다.)"}},
        {"ff플레이리스트", new List<string>(){"요즘 무슨 노래 듣냐고? 음…", "나도 노래는 잘 몰라. ", "(두 사람이 공감대를 형성합니다. 서로에 대한 친밀도가 상승합니다.)"}},
        {"tf플레이리스트", new List<string>(){"너희 요즘 무슨 노래 들어? 난 이거 좋던데. ", "난 노래를 잘 안 들어. ", "(대화거리가 더 이상 없어보입니다. 서로에 대한 친밀도가 하락합니다.)"}},

        {"tt위시리스트", new List<string>(){"나 요즘 사고 싶은 거 생겼어. ", "오, 어떤건데? 보여줘. ", "(분위기가 좋아보입니다. 모두에 대한 친밀도가 상승합니다.)"}},
        {"ff위시리스트", new List<string>(){"사고 싶은 거 있냐고? 지금?", "난 별 생각이 나지 않아. ", "(두 사람이 공감대를 형성합니다. 서로에 대한 친밀도가 상승합니다.)"}},
        {"tf위시리스트", new List<string>(){"나 요즘 사고 싶은 거 생겼어. ", "흠… 그래?", "(대화거리가 더 이상 없어보입니다. 서로에 대한 친밀도가 하락합니다.)"}},

        {"ttTMI", new List<string>(){"내가 오늘 TMI 하나 알려줄까?", "긍정: 어, 알고 싶어!", "(분위기가 좋아보입니다. 모두에 대한 친밀도가 상승합니다.)"}},
        {"ffTMI", new List<string>(){"난 쓸데 없는 얘기 하는 게 정말 싫더라. ", "맞아. 난 그래서 그런 얘기 잘 안 하는 편이야", "(두 사람이 공감대를 형성합니다. 서로에 대한 친밀도가 상승합니다.)"}},
        {"tfTMI", new List<string>(){"내가 오늘 TMI 하나 알려줄까?", "왜… 뭔데.", "(대화거리가 더 이상 없어보입니다. 서로에 대한 친밀도가 하락합니다.)"}},

    };
}
