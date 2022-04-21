import logo from './logo.svg';
import './App.css';

function App() {

  const people = ["Aslı","Mikail","Recep","Doğukan","Veli","Salih","Elif","Berkay"]

  return (
    <div>
      <h1>{people[0]}</h1>
      <h1>{people[1]}</h1>
      <h1>{people[2]}</h1>
      <h1>{people[3]}</h1>
      <h1>{people[4]}</h1>
      <h1>{people[5]}</h1>
      <h1>{people[6]}</h1>
      <h1>{people[7]}</h1>
      <hr/>
      <br/><br/>
      
      {people.map((person)=>(
        <h1>{person}</h1>
      ))}
    </div>
  );

  
}

export default App;
