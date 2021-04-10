# EPTA_SPACE_PROGRAM - 0.5.2
Aplicativo para celular Android de jogo Arcade desenvolvido na plataforma **Unity** (**2020.1.3f1**). Com fins de angariar fundos para a equipe **EPTA** (Equipe de Propulsão e Tecnologia Aeroespacial)

## Plano de gestão para 2021-A
No primeiro semestre deste ano será desenvolvida a etapa de pré-lançamento do jogo. Tal atividade engloba a partir da versão **0.5.0** até a **1.0.0** e denota todos os desenvolvimentos para terminar o pre-alpha, alpha e todos os betas, sendo a versão **1.0.0** a primeira que será disponibilizada ao público na **Google Play** em meados de **Março**.

Abaixo encontra-se um roteiro de atividades com datas previstas, pessoas responsáveis e a forma como será levado o versionamento em **GIT**:

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

## Fichamento de implementação de features:


- Felipe J. O. Ribeiro : bug-fixes : 19/01/2021

0.5.0

- Mateus da Silva Fernandes : Salvamento_modular : 23/01/2021;

- Olavo Caetano Inácio : trocar_sprites_on_demand : 23/01/2021
 
- Pedro G. R. V. Melo : Queda_da_tela_inicial : 23/01/2021

- Felipe J. O. Ribeiro : fix_input_jogador : 23/01/2021

0.5.1

- Mateus da Silva Fernandes : Leitura_modular : 03/02/2021;

- Olavo Caetano Inácio : spawn_basico_1 : 01/02/2021

- Pedro G. R. V. Melo : Destruição_Tela_Inicial :04/02/2021

- Felipe J. O. Ribeiro : funcao_morte : 01/02/2021

0.5.2

- Olavo Caetano Inácio : recuo_incial_player : 26/02/2021

- Mateus da Silva Fernandes : Chamada_save_volume : 25/02/2021;

- Pedro G. R. V. Melo : resgatar_npcs :23/02/2021

- Felipe J. O. Ribeiro : spawn_basico_2 : 24/02/2021

0.5.3

- Olavo Caetano Inácio : spawn_metodo_1 : 01/03/2021

- Mateus da Silva Fernandes : chamada_save_morte : 05/03/2021;

- Pedro G. R. V. Melo : pegar_altura :01/03/2021

- Felipe J. O. Ribeiro : botao_iniciar : 06/03/2021

0.5.4

- Olavo Caetano Inácio : Stop_time_disable_general_ui : 13/03/2021

- Mateus da Silva Fernandes : menu_morte : 14/03/2021

- Pedro G. R. V. Melo : altura_interface 13/03/2021

- Felipe J. O. Ribeiro : player_idle_sprite : 14/03/2021

0.5.5

- Olavo Caetano Inácio :

- Mateus da Silva Fernandes : desabilita_player_reload_scene : 27/03/2021;

- Pedro G. R. V. Melo : engine_sound : 20/03/2021

- Felipe J. O. Ribeiro : death_by_colide : 27/03/2021
