const mongoose = require('mongoose');
const EmployeeSchema = new mongoose.Schema({
    name:{
        type: String, //tip belirtiyoruz
        required: true //zorunlu mu değil mi
    },
    age:{
        type:Number,
        required:true
    },
    username:{
        type: String,
        required:true
    }

})
const EmployeeModel = mongoose.model("employees",EmployeeSchema) //verdiğimiz collection adı

module.exports = EmployeeModel //yaptğımız işlenleri export ediyoruz.