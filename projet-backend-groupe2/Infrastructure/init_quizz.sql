use
master
go
drop
database quizz_db
go
create
database quizz_db
go

use quizz_db
go

create table users
(
    user_id  int identity primary key,
    username varchar(50)  not null unique,
    email    varchar(150) not null,
    password varchar(150),
    role     varchar(50)  not null
)
    go

create table themes
(
    theme_id int identity primary key,
    title    varchar(50) not null unique
)
    go

create table quizzes
(
    quizz_id    int identity primary key,
    title       varchar(50)  not null,
    description varchar(500) not null,
    theme_id    int          not null
        constraint fk_quizzes_themes references themes,
    user_id     int          not null
        constraint fk_quizzes_users references users
)
    go


create table questions
(
    question_id        int identity,
    question           varchar(200) not null,
    correct_choice     varchar(100) not null,
    incorrect_choice_1 varchar(100) not null,
    incorrect_choice_2 varchar(100) not null,
    incorrect_choice_3 varchar(100) not null,
    quizz_id           int          not null
        constraint fk_questions_quizzes references quizzes
)
    go

create table scores
(
    score_id int identity,
    score    int not null,
    user_id  int not null
        constraint fk_scores_users references users,
    quizz_id int not null
        constraint fk_scores_quizzes references quizzes
)