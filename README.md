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
