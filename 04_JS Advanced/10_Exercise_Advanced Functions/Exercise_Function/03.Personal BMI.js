function BMIsolve(name, age, weight, heightCm){
    const heightM=heightCm/100;
    const bmi=Math.round(weight/heightM**2);

    let status='';
let output={
    name: name, //може да се пише само name,когато ключа и стойноста са с еднакво име
    personalInfo: {
        age,
        weight,
        height: heightCm
    },
    BMI: bmi,
    status
};
    if(bmi<18.5){
        status='underweight';
    } else if(bmi<25){
        status='normal';
    } else if(bmi<30){
        status='overweight';
    } else{
        status='obese';
        output.recommendation='admission required';
    }
output.status=status;
    return output;
}

console.log(BMIsolve('Peter', 29, 75, 182));
console.log(BMIsolve('Honey Boo Boo', 9, 57, 137));
