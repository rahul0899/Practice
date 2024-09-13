import React from "react";
import "./App.css";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import VerifyEmployeeForm from "./Components/verify-employee";
import AddEmployeeForm from "./Components/add-employee";

function App() {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<VerifyEmployeeForm />} />
                <Route path="/add-employee" element={<AddEmployeeForm />} />
            </Routes>
        </Router>
    );
}

export default App;
