// import ToDoListClassComponent from './components/ToDoList';
import ToDoListFuncComponent from './components/ToDoList';

import './App.css';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <h1>TODO App</h1>
      </header>
      <main>

        {/* <ToDoListClassComponent /> */}
        <ToDoListFuncComponent />

      </main>
      <footer>
        <p>All rigths reserved &copy; byDancho</p>
      </footer>
    </div>
  );
}

export default App;
