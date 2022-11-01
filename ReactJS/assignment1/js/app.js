const students = [
    { name:"Alex", grade: 15, point : 15},
    { name:"Devlin", grade: 15, point : 25},
    { name:"Eagle", grade: 13, point : 12},
    { name:"Sam", grade: 14, point : 26}
]

//sort by name
function compare(a, b) {
    if (a.name < b.name) {
        return -1;
    }
    if (a.name > b.name) {
        return 1;
    }
    
    return 0;
}

console.log(students.sort(compare));

//Sort array by grade in ascending order
let arr = students.sort((a, b) => {
    return a.grade - b.grade;
});

console.log(arr);

//Sort array by grade in decreasing order
let arr2 = students.sort((a, b) => {
    return b.grade - a.grade;
});

console.log(arr2);

//Log all students whose points are greater than 15
let arr3 = students.filter(a => a.point > 15);

//Calculate the total points of all students whose grades are equal 15
let arr4 = students.filter(a => a.grade === 15);
let arr5 = arr4.reduce((total, e) => {
    return total + e.point;
}, 0);

console.log(arr5);

//Remove the student's name called "Sam" from the array then log to console
const newStudent = [...students];
let index = newStudent.findIndex(e => e.name === "Sam");

newStudent.splice(index, 1);

console.log(newStudent);