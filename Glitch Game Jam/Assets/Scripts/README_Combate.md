# Documentação do Sistema de Combate

## Visão Geral

Este documento detalha o funcionamento do sistema de combate, desde a configuração dos componentes até o fluxo de jogo. O sistema é gerenciado principalmente pelo `CombatManager`, que orquestra os turnos, eventos e condições de vitória/derrota.

## Componentes Principais

### Creature.cs

A classe `Creature` representa qualquer entidade de combate no campo. Para configurar uma criatura, siga estas etapas:

1.  **Atributos:**
    *   `creatureName`: O nome da criatura.
    *   `health`/`maxHealth`: Os pontos de vida da criatura.
    *   `attackPower`: O dano que a criatura causa.
    *   `isEnemy`: Marque esta opção se a criatura pertencer ao oponente.

2.  **Ações:**
    *   O método `PerformAction()` define o comportamento da criatura durante o turno do oponente. Atualmente, a IA ataca o jogador diretamente.

### Card.cs

A classe `Card` é um `ScriptableObject` que define as cartas do jogo. Para criar ou configurar uma carta:

1.  **Atributos:**
    *   `name`/`description`: O nome e a descrição da carta.
    *   `costValue`: O custo de `mana` para jogar a carta.

2.  **Habilidades (`Skills`):**
    *   A lista `skills` contém as ações que a carta executa ao ser jogada. Adicione `DamageSkill` ou `HealSkill` e configure seus parâmetros (`damageAmount`, `healAmount`, `target`).

### Player.cs

A classe `Player` gerencia o estado do jogador. Os atributos principais são:

*   `essence`/`maxEssence`: Os pontos de vida do jogador.
*   `mana`/`maxMana`: Os recursos do jogador para jogar cartas.

## Fluxo do Combate

O `CombatManager` gerencia o combate através de uma máquina de estados:

1.  **PREPARATION:**
    *   A mão inicial de 7 cartas é comprada.
    *   A lógica de "mulligan" é executada.

2.  **PLAYERTURN:**
    *   O jogador pode jogar quantas cartas puder pagar.
    *   Quando uma carta é jogada, seu custo de `mana` é deduzido, e suas habilidades são acionadas.

3.  **ENEMYTURN:**
    *   Cada criatura inimiga executa sua `PerformAction()`.
    *   Se o jogador não tiver criaturas em campo, ele perde 1 de "Essência".

4.  **VICTORY/DEFEAT:**
    *   No final de cada turno, o `CombatManager` verifica se o `Challenge` foi concluído (vitória) ou se a "Essência" do jogador chegou a zero (derrota).
