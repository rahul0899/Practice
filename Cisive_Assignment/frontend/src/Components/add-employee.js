import React, { useState } from "react";
import axios from "axios";
import { Link } from "react-router-dom";

const AddEmployeeForm = () => {
    const [formData, setFormData] = useState({
        employeeName: "",
        companyName: "",
    });

    const [response, setResponse] = useState(null);
    const [errors, setErrors] = useState({});

    const handleSubmit = async (e) => {
        e.preventDefault();

        // Validate form data
        const validationErrors = validateForm(formData);
        if (Object.keys(validationErrors).length > 0) {
            setErrors(validationErrors);
            return;
        }

        try {
            const result = await axios.post(
                "https://localhost:44391/api/addemployee",
                formData
            );
            setResponse(result.data);
            setErrors({}); // Clear errors on successful submission
        } catch (error) {
            console.error("Error submitting the form", error);
        }
    };

    const validateForm = (form) => {
        const errors = {};
        if (!form.employeeName) {
            errors.employeeName = "Employee Name is required.";
        }
        if (!form.companyName) {
            errors.companyName = "Company Name is required.";
        }
        return errors;
    };

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setFormData((prevState) => ({ ...prevState, [name]: value }));
        setErrors((prevErrors) => ({ ...prevErrors, [name]: "" })); // Clear errors as user types
    };

    const handleClear = () => {
        setFormData({
            employeeName: "",
            companyName: "",
        });
        setErrors({});
        setResponse(null); // Clear response on form reset
    };

    return (
        <div className="max-w-lg mx-auto p-4">
            <h1 className="text-2xl font-bold mb-4">Employee Registration</h1>

            <form onSubmit={handleSubmit}>
                <div className="mb-4">
                    <label className="block mb-2">Employee Name</label>
                    <input
                        type="text"
                        name="employeeName"
                        value={formData.employeeName}
                        onChange={handleInputChange}
                        className={`w-full p-2 border ${
                            errors.employeeName
                                ? "border-red-500"
                                : "border-gray-300"
                        } rounded`}
                        required
                    />
                    {errors.employeeName && (
                        <p className="text-red-500 text-sm mt-1">
                            {errors.employeeName}
                        </p>
                    )}
                </div>

                <div className="mb-4">
                    <label className="block mb-2">Company Name</label>
                    <input
                        type="text"
                        name="companyName"
                        value={formData.companyName}
                        onChange={handleInputChange}
                        className={`w-full p-2 border ${
                            errors.companyName
                                ? "border-red-500"
                                : "border-gray-300"
                        } rounded`}
                        required
                    />
                    {errors.companyName && (
                        <p className="text-red-500 text-sm mt-1">
                            {errors.companyName}
                        </p>
                    )}
                </div>

                <div className="flex gap-4">
                    <button
                        type="submit"
                        className="px-4 py-2 bg-green-500 text-white rounded"
                    >
                        Submit
                    </button>
                    <button
                        type="button"
                        onClick={handleClear}
                        className="mx-5 px-4 py-2 bg-red-800 text-white rounded"
                    >
                        Clear
                    </button>
                </div>
            </form>

            <div className="mt-4">
                <p>
                    <Link to="/" className="text-blue-500 underline">
                        Verify Employee
                    </Link>
                </p>
            </div>

            {response && (
                <div className="mt-4 p-4 bg-gray-100">
                    <h2 className="text-xl font-semibold">Employee Created:</h2>
                    <p>
                        <strong>ID:</strong> {response.employeeId}
                    </p>
                    <p>
                        <strong>Number:</strong> {response.employeeNumber}
                    </p>
                    <p>
                        <strong>Name:</strong> {response.employeeName}
                    </p>
                    <p>
                        <strong>Company:</strong> {response.companyName}
                    </p>
                </div>
            )}
        </div>
    );
};

export default AddEmployeeForm;
