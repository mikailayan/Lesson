const mongoose = require("mongoose");
const LibrarySchema = new mongoose.Schema({
    isbn:{
        type:String,
        required:true
    },
    name:{
        type:String,
        required:true
    },
    author:{
        type:String,
        required:true
    },
    publisher:{
        type:String,
        required:true
    },
    publishdate:{
        type:String,
        required:true
    },
    pagenumbers:{
        type:Number,
        required:true
    },
    image:{
        type:String,
        required:false
    }
})
const LibraryModel = mongoose.model("library",LibrarySchema)
module.exports =LibraryModel