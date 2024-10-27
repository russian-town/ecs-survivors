using System.Collections;
using Code.Gameplay;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.Systems;

namespace Code.Infrastructure.States.GameStates
{
  public class BattleLoopState : IState, IUpdateable
  {
    private readonly GameContext _gameContext;
    private readonly ISystemFactory _systems;
    
    private BattleFeature _battleFeature;

    public BattleLoopState(ISystemFactory systems, GameContext gameContext)
    {
      _gameContext = gameContext;
      _systems = systems;
    }
    
    public void Enter()
    {
      _battleFeature = _systems.Create<BattleFeature>();
      _battleFeature.Initialize();
    }

    public void Update()
    {
      _battleFeature.Execute();
      _battleFeature.Cleanup();
    }

    public void Exit()
    {
      _battleFeature.DeactivateReactiveSystems();
      _battleFeature.ClearReactiveSystems();

      DestructEntities();
      
      _battleFeature.Cleanup();
      _battleFeature.TearDown();
      _battleFeature = null;
    }

    private void DestructEntities()
    {
      foreach (var entity in _gameContext.GetEntities())
        entity.isDestructed = true;
    }
  }
}