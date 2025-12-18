# Documentação dos Sistemas do Jogo

## GameState

O `GameState` é um singleton que atua como o sistema central de eventos do jogo. Ele desacopla os diferentes sistemas de jogo, permitindo que eles se comuniquem sem manter referências diretas uns aos outros.

### Eventos

- `OnRoundStart`: Acionado no início de cada rodada.
- `OnRoundEnd`: Acionado no final de cada rodada.
- `OnCardPlayed`: Acionado quando uma carta é jogada.
- `OnCreatureDestroyed`: Acionado quando uma criatura é destruída.
- `OnCreatureSummoned`: Acionado quando uma criatura é convocada.

## ChallengeManager

O `ChallengeManager` é responsável por gerenciar o ciclo de vida do desafio ativo. Ele lida com a configuração, verificação de conclusão e desmontagem dos desafios.

### Funcionalidade

- Um desafio ativo (`activeChallenge`) é atribuído ao gerente.
- No `Start`, o desafio é configurado usando `activeChallenge.Setup()`.
- No `Update`, ele verifica continuamente se o desafio foi concluído usando `activeChallenge.IsCompleted()`.
- Após a conclusão, a recompensa do desafio é processada, e o desafio é desmontado usando `activeChallenge.Teardown()`.

## BlessingManager

O `BlessingManager` é responsável por gerenciar as bênçãos ativas no jogo.

### Funcionalidade

- **Adicionar Bênção**: `AddBlessing(Blessing blessing, GameObject target)` instancia e adiciona uma bênção à lista de bênçãos ativas.
- **Remover Bênção**: `RemoveBlessing(Blessing blessing)` remove uma bênção da lista de bênçãos ativas.
- **Aplicar Efeitos de Bênção**: No início de cada rodada (`OnRoundStart`), `ApplyBlessingEffects()` é chamado para atualizar a duração de cada bênção e remover aquelas que expiraram.

## RewardManager

O `RewardManager` lida com a apresentação das escolhas de recompensa ao jogador.

### Funcionalidade

- **Apresentar Escolha de Recompensa**: `PresentRewardChoice(Reward reward, GameObject target)` exibe as opções de recompensa disponíveis (cartas ou bênçãos) e aguarda a entrada do jogador.
- **Acionar Recompensa**: `TriggerReward(Reward reward, GameObject target)` inicia a corrotina para apresentar a escolha de recompensa.

## DeckManager

O `DeckManager` é um singleton que gerencia o baralho de cartas do jogador.

### Funcionalidade

- **Adicionar Carta**: `AddCard(Card card)` adiciona uma carta ao baralho do jogador.

## CreatureRegistry

O `CreatureRegistry` é um singleton que rastreia todas as criaturas ativas na cena.

### Funcionalidade

- **Registrar Criatura**: `Register(Creature creature)` adiciona uma criatura à lista de criaturas ativas.
- **Cancelar Registro de Criatura**: `Unregister(Creature creature)` remove uma criatura da lista de criaturas ativas.
- **Criaturas Ativas**: A propriedade `ActiveCreatures` fornece uma lista somente leitura de todas as criaturas ativas.

## CombatManager

O `CombatManager` orquestra os turnos, eventos e condições de vitória/derrota no sistema de combate.

### Componentes Principais

#### Creature.cs

A classe `Creature` representa qualquer entidade de combate no campo.

- **Atributos:**
    - `creatureName`: O nome da criatura.
    - `health`/`maxHealth`: Os pontos de vida da criatura.
    - `attackPower`: O dano que a criatura causa.
    - `isEnemy`: Marque esta opção se a criatura pertencer ao oponente.
- **Ações:**
    - O método `PerformAction()` define o comportamento da criatura durante o turno do oponente.

#### Card.cs

A classe `Card` é um `ScriptableObject` que define as cartas do jogo.

- **Atributos:**
    - `name`/`description`: O nome e a descrição da carta.
    - `costValue`: O custo de `mana` para jogar a carta.
- **Habilidades (`Skills`):**
    - A lista `skills` contém as ações que a carta executa ao ser jogada (ex: `DamageSkill`, `HealSkill`).

#### Player.cs

A classe `Player` gerencia o estado do jogador.

- `essence`/`maxEssence`: Os pontos de vida do jogador.
- `mana`/`maxMana`: Os recursos do jogador para jogar cartas.

### Fluxo do Combate

O `CombatManager` gerencia o combate através de uma máquina de estados:

1.  **PREPARATION:**
    - A mão inicial é comprada e a lógica de "mulligan" é executada.
2.  **PLAYERTURN:**
    - O jogador pode jogar cartas, deduzindo seu custo de `mana` e acionando suas habilidades.
3.  **ENEMYTURN:**
    - Cada criatura inimiga executa sua `PerformAction()`.
    - Se o jogador não tiver criaturas em campo, ele perde "Essência".
4.  **VICTORY/DEFEAT:**
    - No final de cada turno, o `CombatManager` verifica se o `Challenge` foi concluído (vitória) ou se a "Essência" do jogador chegou a zero (derrota).
