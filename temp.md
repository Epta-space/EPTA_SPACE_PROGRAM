# graphy

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

|EPTA_SPACE_PROGRAM|
start
:0.5.0 - Prealpha inicial - 19/jan;


|EPTA_SPACE_PROGRAM|
fork
|Felipe Ribeiro|
:fix_input_jogador;
fork again
|Matheus Fernandes|
:salvamento_modular;
fork again
|Olavo Inácio|
:trocar_sprites_on_demand;
fork again
|Pedro Melo|
:Queda_da_tela_inicial;
|EPTA_SPACE_PROGRAM|
end fork
:0.5.1 - Prealpha - 30/jan;


fork
|Felipe Ribeiro|
:funcao_morte;
fork again
|Matheus Fernandes|
:leitura_modular;
fork again
|Olavo Inácio|
:spawn_basico_1;
fork again
|Pedro Melo|
:destruicao_tela_inicial;
|EPTA_SPACE_PROGRAM|
end fork
:0.5.2 - Prealpha - 20/fev;

fork
|Felipe Ribeiro|
:spawn_basico_2;
fork again
|Matheus Fernandes|
:chamada_save_volume;
fork again
|Olavo Inácio|
:recuo_inicial_player;
fork again
|Pedro Melo|
:resgatar_npcs;
|EPTA_SPACE_PROGRAM|
end fork
:0.5.3 - Prealpha - 27/fev;


stop


@enduml

```
</div>

![](table_with_developers.svg)
