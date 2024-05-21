using System;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private Wallet _wallet;


    public override void InstallBindings()
    {
        Container.Bind<Wallet>().FromInstance(_wallet);

        
        // var calculator = SelectCalculator(_calculatorType);
        // Container.Bind<IDamageCalculator>().FromInstance(calculator);

    }
}
