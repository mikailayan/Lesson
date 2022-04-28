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
    const employee = req.body;
    const newEmployee= new EmployeeModel(employee);
    await newEmployee.save();
    res.json(employee);
})
app.delete("/deleteEmployee/:id", async (req,res) =>{
    const id=req.params.id;
    await EmployeeModel.findByIdAndRemove(id).exec();
    res.send("deleted");
});

app.listen(3030,()=>{
    console.log("Server Çalışıyor....!!")
})

app.put("/updateEmployee", async (req,res)=> {
    const newName = req.body.newName;
    const newAge = req.body.newAge;
    const id = req.body.id;
    try {
        await EmployeeModel.findById(id,(error,updatedEmployee)=>{
            updatedEmployee.name= newName;
            updatedEmployee.age= newAge;
            updatedEmployee.save();


        });
    } catch (error) {
        console.log(error);
    }
    res.json("updated");
});