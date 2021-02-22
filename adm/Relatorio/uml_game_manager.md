# UML para o script do game manager

Ola a todos.

<div style='text-align:center'>

```plantuml

@startuml table_with_developers

!define DARKBLUE
!includeurl https://raw.githubusercontent.com/Drakemor/RedDress-PlantUML/master/style.puml
skinparam {

ParticipantFontname Times
ParticipantBorderColor white
ParticipantBackgroundColor #282A36
ParticipantFontSize 12

classFontColor white
classFontName Times
classFontSize 16

ArrowFontName Times
ArrowFontSize 14
ArrowColor white

ActorBackgroundColor #282A36
ActorBorderColor white
ActorFontColor white
ActorFontSize 16
ActorFontName Times

SwimlaneTitleFontColor White
SwimlaneBorderColor white
SwimlaneTitleFontSize 16
SwimlaneTitleFontName Times
SwimlaneBorderThickness 2

ActivityBarColor #black

''backgroundColor null 
backgroundColor #282A36
}

class Game_Manager {
    -int phase = 0;
    -GameObject player;
    -float phase_time;
    -float next_phase;
    -float game_time;
    -float[] phase_plan = new float[2]{10.0f, 10.0f};

    void start()
    void update()

    +float Get_player_x()
    +GameObject Get_player()
    +int Get_phase()
    +float Get_phase_time()
    +float Get_phase_fraction()
    +float Get_time()
}


class End_Handler {
    -GameObject G_Manager
    -GameObject S_Options
    -GameObject Player
    -GameObject UI_Handler

    void start()
    +void End_Game()
    -void Disabilitar_Input_Jogador()
    -void Disable_General_UI()
    -void Explode_Player()
    -void Time_Stop()
    -void Enable_Intersticial_Add()
}

class Save_Options{

}

End_Handler <- Game_Manager : End_Game()
End_Handler -> Save_Options : save_value()

@enduml

```
</div>
