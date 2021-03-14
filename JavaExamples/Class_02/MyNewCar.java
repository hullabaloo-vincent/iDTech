public class MyNewCar extends Car{

    public MyNewCar(String model, int year) {
        super(model, year);
        super.callMe();
    }
}