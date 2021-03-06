using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    internal class Constants
    {
        public const bool PROGRAM_ON = true;
        public const bool PROGRAM_OFF= false;
        public const int WIDTH = 180;
        public const int LOGIN_SUCCESS = 1;
        public const int LOGIN_FAIL = 0;
        public const int LOGIN_OFF = -1;


        public const int STOP = -1;
        public const int CONTINUE = 1;
        public const int LECTURE_TIME_CHECK = 1;
        public const int LECTURE_INTERESTING = 2;
        public const int LECTURE_SUBSCRIPTION = 3;
        public const int LECTURE_SUBSCRIPTION_RESULT = 4;

        public const int LECTURE_DEPARTMENT = 1; // 개설 학과 전공
        public const int LECTURE_DIVISION = 2; // 이수구분
        public const int LECTURE_CLASSNUMBER = 2; // 학수번호,분반
        public const int LECTURE_NAME = 3; // 교과목명
        public const int PROFESSOR = 4; // 교수명
        public const int GRADE = 5; // 학년
        public const int CHECK = 6; // 조회
        public const int INTEREST = 7; // 관심과목

        public const int LECTURE_ALL = 1; // 전체학부
        public const int COMPUTER_DEPARTMENT = 2; // 컴퓨터공학과
        public const int INTELLIGENT_DEPARTMENT = 3; // 지능기전공학부
        public const int SOFTWARE_DEPARTMENT = 4; //소프트웨어학과
        public const int AEROSPACE_DEPARTMENT = 5; //기계항공우주공학부

        public const int GYOYANG_PILSU_CLASS = 2; // 교양필수
        public const int JEONGONG_PILSU_CLASS = 3; // 전공필수
        public const int JEONGONG_SEONTAEG = 4; // 전공선택

        public const int FIRST_CLASS = 2; //1학년
        public const int SECOND_CLASS = 3;//2학년
        public const int THIRD_CLASS = 4;//3학년
        public const int FOUR_CLASS = 5;//4학년

        public const int LECTURE_SEARCH = 1; //과목 분야별 검색
        public const int LECTURE_LIST = 2;// 과목 강의 내역
        public const int LECTURE_SCHEDULE = 3; // 과목 시간표
        public const int LECTURE_DELETE = 4; // 과목 삭제


        public const int LECTURE_CHECK = 1; //강의 시간표 조회
        public const int INTEREST_LECTURE_SELECTION = 2;// 관심과목 담기
        public const int LECTURE_APPLICATION = 3; // 수강신청
        public const int LECTURE__APPLICATION_LIST = 4; // 과목 삭제


        public const int REINPUT = 1;
        public const int BACK = 0;

        public const int TIMEOVERLAP = 1; // 시간표 겹칠때
        public const int NONTIMEOVERLAP = 0; // 시간표 안겹칠때

        public const string INPUT_EMPTY = "";

        public const int COUNT_ZERO = 0;

        public const int MONDAY = 13; // 요일
        public const int TUESDAY = 46;
        public const int WEDNESDAY = 79;
        public const int THURSDAY = 112;
        public const int FRIDAY = 145;

        public const int TIMETABLE_MONDAY = 2; // 시간표 엑셀에 넣을 때 요일
        public const int TIMETABLE_TUESDAY = 3;
        public const int TIMETABLE_WEDNESDAY = 4;
        public const int TIMETABLE_THURSDAY = 5;
        public const int TIMETABLE_FRIDAY = 6;

        public const int FIRST_TIMETYPE = 1;
        public const int SECOND_TIMETYPE = 4;
        public const int THIRD_TIMETYPE = 2;










































    }
}
