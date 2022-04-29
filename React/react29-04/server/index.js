const express = require("express")
const app = express()

app.listen(3030,()=>{
    console.log("Server Çalışıyor")
})

const cors = require("cors")
const LibraryModel = require("./models/Library")
app.use(cors())

app.post("/createLibrary", async (req,res)=>{
    const library = req.body
    const newLibrary = new LibraryModel(library)
    await newLibrary.save()
})

const LibraryModel = require('./models/Library')

LibraryModel.find({},(err,result)=>{
    if (err) {
        {
            res.json(err)
        }
        //burda kaldın.
})