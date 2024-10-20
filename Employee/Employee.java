/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Main.java to edit this template
 */
package employee;

import java.util.ArrayList;
import java.util.Scanner;

/**
 *
 * @author tmgn_bleble
 */
public class Employee {

    private String firstname, lastname, job;
    private int salary;

    public Employee(String firstname, String lastname, String job, int salary) {
        this.firstname = firstname;
        this.lastname = lastname;
        this.job = job;
        this.salary = salary;
    }

    public String getFirstName(){return firstname; }

    public String getLastname() {
        return lastname;
    }

    public String getJob() {
        return job;
    }

    public int getSalary() {
        return salary;
    }
    
    public void raiseSalary(int percent){
        salary = (int)(salary*(1.0 + percent/100.0));
    }
    
    public static String ReadString(String msg, Scanner sc){
        System.out.print(msg);
        return sc.nextLine();
    }
    
    public static int ReadInt(String msg, Scanner sc){
        System.out.print(msg);
        int i = sc.nextInt();
        sc.nextLine();
        return i;
    }

    @Override
    public String toString() {
        return firstname + " " + lastname + ", job=" + job + ", salary=" + salary ;
    }
    
    
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        ArrayList<Employee> employees = new ArrayList<>();
        
        for (int i=0; i <=3; i++){
            Employee e = readEmployee(sc);
            employees.add(e);
            System.out.println(e);
        }
        
        String job = ReadString("Job to raise the salary: ", sc);
        int raise = ReadInt("Amount of raise: ", sc);
        
        for (Employee e : employees){
            if(e.getJob().equals(job)){
                e.raiseSalary(raise);
                System.out.println(e);

            }
        }
        
        Employee richMan = employees.get(0);
        for(Employee e : employees){
            if(richMan.getSalary() < e.getSalary()){
                richMan = e;
            }
        }
        System.out.print("Richest employee is: " + richMan);
    }

    private static Employee readEmployee(Scanner sc) {
        String firstname = ReadString("First name: ", sc);
        String lastname = ReadString("Last name: ", sc);
        String job = ReadString("Job: ", sc);
        int salary = ReadInt("Salary: ", sc);
        Employee e = new Employee(firstname, lastname, job, salary);
        return e;
    }
    
}
