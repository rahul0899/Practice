import React, { useEffect, useState } from "react";
import axios from "axios";
import { Link } from "react-router-dom";

const VerifyEmployeeForm = () => {
    const [formData, setFormData] = useState({
        employeeNumber: "",
        companyName: "",
        enteredVerificationCode: "",
    });

    const [errors, setErrors] = useState({});
    const [verificationStatus, setVerificationStatus] = useState(null);
    const [generatedCode, setGeneratedCode] = useState("");

    // Generate a random verification code
    const generateVerificationCode = () => {
        const code = Math.random().toString(36).substring(2, 8).toUpperCase(); // Generate a 6-character random code
        setGeneratedCode(code);
    };

    // On component mount, generate the default verification code
    useEffect(() => {
        generateVerificationCode();
    }, []);

    // Handle form submission with validation checks
    const handleSubmit = async (e) => {
        e.preventDefault();

        const validationErrors = validateForm(formData);
        if (Object.keys(validationErrors).length > 0) {
            setErrors(validationErrors); // If errors, set error state
            return;
        }

        if (formData.enteredVerificationCode === generatedCode) {
            try {
                const result = await axios.post(
                    "https://localhost:44391/api/verifyemployee",
                    formData
                );
                setVerificationStatus(result.data.status); // Set the verification status from the API response
            } catch (error) {
                console.error("Error verifying the employee", error);
            }
        } else {
            setVerificationStatus("Verification code does not match.");
        }
    };

    // Validate form inputs
    const validateForm = (form) => {
        const errors = {};
        if (!form.employeeNumber) {
            errors.employeeNumber = "Employee Number is required.";
        }
        if (!form.companyName) {
            errors.companyName = "Company Name is required.";
        }
        if (!form.enteredVerificationCode) {
            errors.enteredVerificationCode =
                "Please enter the verification code.";
        }
        return errors;
    };

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setFormData((prevState) => ({ ...prevState, [name]: value }));
        setErrors((prevErrors) => ({ ...prevErrors, [name]: "" }));
    };

    const handleClear = () => {
        setFormData({
            employeeNumber: "",
            companyName: "",
            enteredVerificationCode: "",
        });
        setErrors({});
        setVerificationStatus(null);
        generateVerificationCode();
    };

    return (
        <div className="max-w-lg mx-auto p-4">
            <h1 className="text-2xl font-bold mb-4">Verify Employee</h1>

            <form onSubmit={handleSubmit}>
                <div className="mb-4">
                    <label className="block mb-2">Employee Number</label>
                    <input
                        type="number"
                        name="employeeNumber"
                        value={formData.employeeNumber}
                        onChange={handleInputChange}
                        className={`w-full p-2 border ${
                            errors.employeeNumber
                                ? "border-red-500"
                                : "border-gray-300"
                        } rounded`}
                    />
                    {errors.employeeNumber && (
                        <p className="text-red-500 text-sm mt-1">
                            {errors.employeeNumber}
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
                    />
                    {errors.companyName && (
                        <p className="text-red-500 text-sm mt-1">
                            {errors.companyName}
                        </p>
                    )}
                </div>

                <div className="mb-4">
                    <label className="block mb-2">Verification Code</label>
                    <div className="flex items-center mb-2">
                        <input
                            type="text"
                            value={generatedCode}
                            readOnly
                            className="w-full p-2 border border-gray-300 rounded mr-2"
                        />
                        <button
                            type="button"
                            onClick={generateVerificationCode}
                            className="px-4 py-2 bg-blue-500 text-white rounded"
                        >
                            Refresh
                        </button>
                    </div>
                    <label className="block mb-2">
                        Enter Verification Code
                    </label>
                    <input
                        type="text"
                        name="enteredVerificationCode"
                        value={formData.enteredVerificationCode}
                        onChange={handleInputChange}
                        className={`w-full p-2 border ${
                            errors.enteredVerificationCode
                                ? "border-red-500"
                                : "border-gray-300"
                        } rounded`}
                    />
                    {errors.enteredVerificationCode && (
                        <p className="text-red-500 text-sm mt-1">
                            {errors.enteredVerificationCode}
                        </p>
                    )}
                </div>

                <button
                    type="submit"
                    className="px-4 py-2 bg-green-500 text-white rounded"
                >
                    Verify
                </button>
                <button
                    type="button"
                    onClick={handleClear}
                    className="mx-5 px-4 py-2 bg-red-800 text-white rounded"
                >
                    Clear
                </button>
            </form>

            {verificationStatus && (
                <div
                    className={`mt-4 p-4 ${
                        verificationStatus === "Verified"
                            ? "bg-green-100 text-green-700"
                            : "bg-red-100 text-red-700"
                    }`}
                >
                    <h2 className="text-xl font-semibold">
                        Verification Status:
                    </h2>
                    <p>{verificationStatus}</p>
                </div>
            )}

            <div className="mt-4">
                <p>
                    <Link
                        to="/add-employee"
                        className="text-blue-500 underline"
                    >
                        Add Employee
                    </Link>
                </p>
            </div>
        </div>
    );
};

export default VerifyEmployeeForm;
