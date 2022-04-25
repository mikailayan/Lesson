const EmployeeModel = require('./models/Employess');

const express= require("express")
const app = express()

const cors = require("cors") 
app.use(cors())
app.use(express.json())

const mongoose = require('mongoose');
mongoose.connect("mongodb+srv://admin:123@cluster0.4ppn8.mongodb.net/fullstack?retryWrites=true&w=majority")

app.get("/getEmployees",(req,res)=>{
    EmployeeModel.find({},(err,result)=>{
        if (err)
        {
            res.json(err)
        }
        else
        {
            res.json(result)
        }
    })
})
app.post("/createEmployee", async (req,res)=>{
    const employee = req.body
    const newEmployee= new EmployeeModel(employee)
    await newEmployee.save()
    res.json(employee)
})

app.listen(3030,()=>{
    console.log("Server Çalışıyor....!!")
})