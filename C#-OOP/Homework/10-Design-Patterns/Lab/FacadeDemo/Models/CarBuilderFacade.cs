﻿namespace FacadeDemo.Models;

public class CarBuilderFacade
{
    public CarBuilderFacade()
    {
        Car = new Car();
    }

    public CarInfoBuilder Info => new CarInfoBuilder(Car);
    public CarAddressBuilder Built => new CarAddressBuilder(Car);

    protected Car Car { get; set; }

    public Car Build() => Car;

}