# Employment Verification Service

The Employment Verification Service is a web application that provides a streamlined approach to verifying employment details for various employees. It includes features for adding and verifying employee information, handling verification codes, and more.

## Table of Contents

-   [Installation](#installation)
    -   [Frontend](#frontend)
    -   [Backend](#backend)
-   [Usage](#usage)
-   [API Endpoints](#api-endpoints)
-   [License](#license)

## Installation

### Frontend

1. Navigate to the `frontend` directory:

    cd frontend

2. Install the required dependencies using npm:

    npm install

### Backend

1. Navigate to the `Backend/EmployeeVerificationBackend` directory:

    cd Backend/EmployeeVerificationBackend

2. Update the database connection settings in `appsettings.json`:

    - Open `appsettings.json` and update the `ConnectionStrings` section with your database server details.

3. Apply database migrations:

    - Ensure you have the Entity Framework Core tools installed.
    - Run the following command to update the database schema:
      dotnet ef database update
      OR
      Manually Install the dependencies from the project using Nuget Package Manager

## Usage

### Running the Application

1. **Frontend**:

    - Navigate to the `frontend` directory:

        cd frontend

    - Start the development server with:

        npm start

    - The frontend will be accessible at `http://localhost:3000`.

2. **Backend**:

    - Navigate to the `Backend/EmployeeVerificationBackend` directory:

        cd Backend/EmployeeVerificationBackend

    - Run the application with:

        dotnet run OR RUN on IIS Server

    - The API will be accessible at `https://localhost:44391`.

### Accessing the Application

-   **Frontend Interface**:

    -   Visit `http://localhost:3000` to interact with the web application.
    -   Use the interface to add employees, verify their details, and handle verification codes.

-   **Backend API**:
    -   The API endpoints can be accessed and tested using tools like Postman or Swagger.

## API Endpoints

### Add Employee

-   **Endpoint**: `POST /api/addemployee`
-   **Description**: Adds a new employee to the database.
-   **Request Body**:
    json
    {
    "employeeName": "John Doe",
    "companyName": "Example Corp",
    }
-   **Response**:
    json
    {
    "employeeId": "guid",
    "employeeNumber": 1,
    "employeeName": "John Doe",
    "companyName": "Example Corp",
    }

### Verify Employee

-   **Endpoint**: `POST /api/verifyemployee`
-   **Description**: Verifies employee details.
-   **Request Body**:
    json
    {
    "employeeNumber": 1,
    "companyName": "Example Corp",
    }
-   **Response**:
    json
    {
    "status": "Verified" // or "Not Verified"
    }

## License

This project is licensed under the MIT License. For more details, see the [LICENSE](LICENSE) file.
