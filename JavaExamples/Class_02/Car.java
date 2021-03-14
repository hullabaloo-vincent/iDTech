public class Car{
    private String carModel;
    public static int carYear;
    
    public Car(String model, int year){
        this.carModel = model;
        this.carYear = year;
    }

    public void setType(String newModel){
        this.carModel = newModel;
    }

    public String getType(){
        return carModel;
    }

    public int getYear(){
        return carYear;
    }

    public void callMe(){
        System.out.println("I've been called");
    }
}