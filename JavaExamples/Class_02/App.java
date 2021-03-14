class App {
    public static void main(String[] args) throws Exception {
        final float myFinalVar = 10;
        //myFinalVar = 3;
        Car MyCar = new Car("BeeMobile", 2021);
        Car MyOtherCar = new Car("BatMobile", 2020);
        MyCar.setType("Honda");
        System.out.println(MyCar.getType());
        System.out.println(MyOtherCar.getType());
        MyNewCar ExtendedCar = new MyNewCar("Test", 2019);
        System.out.println(ExtendedCar.getType());
        System.out.println(MyCar.getYear() + " : " + MyOtherCar.getYear() + " : " + ExtendedCar.getYear());
    }
}