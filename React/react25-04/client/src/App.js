import { useEffect, useState } from 'react';
import './App.css';
import axios from 'axios';

function App() {
  const [employees, setEmployees] = useState([]);
  const [name, SetName] = useState("");
  const [age, SetAge] = useState(0);
  const [username, SetUserName] = useState("");
  const [url, SetUserurl] = useState("");
  const [newName, SetNewName] = useState("");
  const [newAge, SetNewAge] = useState(0);






  useEffect(() => {
    axios
      .get("http://localhost:3030/getEmployees")
      .then((response) => setEmployees(response.data))
      .catch((err) => console.log(err))
  }, [employees])

  const deleteEmployee=(id)=>{
    axios.delete(`http://localhost:3030/deleteEmployee/${id}`);
  };

  const createEmployee = () => {
    axios
      .post("http://localhost:3030/createEmployee", {
        name: name,
        age: age,
        username: username,
        url : url
        

      }).then((res) => {
        alert("Employee Created")
      })
  }
  const updateEmployee = (id) => {
    axios
    .put("http://localhost:3030/updateEmployee", {
      id : id,
      newName : newName,
      newAge : newAge
    })
    .then((res)=>{
      alert("Employee Updated");
    });
  };

  return (

    <div className="App"   >
      <div className='row'>
        {employees.map((employee) => (
          <div className='col-md-4 d-flex justify-content-around mb-3'>
            <div className="card bg-dark text-white opacity-75" style={{ width: '18rem' } }>
              <img src={employee.url == "" ? "https://picsum.photos/seed/picsum/300/260" :employee.url} className="card-img-top rounded-circle" alt="..." style={{height:'260px'}} />
              <div className="card-body">
                <h5 className="card-title">{employee.name}</h5>
                <p className="card-text">{employee.age}</p>
                <input placeholder='Güncellenecek adı gir' type='text' onChange={(e) => SetNewName(e.target.value)} />
                <input placeholder='Güncellenecek Yaşı gir' type='Number' onChange={(e) => SetNewAge(e.target.value)} />
                <a href="#" className="btn btn-primary d-block" onClick={() => updateEmployee(employee._id)}>Güncelle</a>
                <a href="#" className="btn btn-danger" onClick={() => deleteEmployee(employee._id)}>Sil</a>

                <h5 className="card-title">{employee.username}</h5>
              </div>
            </div>
            {/* <h1>Name:{employee.name}</h1>
          <h1>Age:{employee.age}</h1>
          <h1>Username:{employee.username}</h1> */}
          </div>
        ))}
      </div>
      <br />
      <br />
      <div>
        <center>
          <input placeholder='isim giriniz' type="text" onChange={(e) => SetName(e.target.value)} />
          <input placeholder='Yaş giriniz' type="number" onChange={(e) => SetAge(e.target.value)} />
          <input placeholder='Kullanıcı adı giriniz' type="text" onChange={(e) => SetUserName(e.target.value)} />
          <input placeholder='url gir' type="text" onChange={(e) => SetUserurl(e.target.value)} />
          <br />
          <button onClick={createEmployee}>Create Emplotee</button>
        </center>
      </div>
    </div>


  );
}
export default App;
