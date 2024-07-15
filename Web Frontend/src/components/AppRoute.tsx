import React from "react";
import { Route, Routes, BrowserRouter } from "react-router-dom";
import Home from "./pages/home/Home";
import DashBoard from "./pages/DashBoard";
import Login from "./pages/Login";
import ResetPassword from "./pages/ResetPassword";
import Register from "./pages/Register";
import Profile from "./pages/Profile";
import CoursesMarks from "./pages/CoursesMarks";
import TutorialMarks from "./pages/TutorialMarks";
import CoursesTeachers from "./pages/CoursesTeachers";
import Attendance from "./pages/Attendance";
import Customer from "./pages/Customer";
import Employee from "./pages/Employee";
import User from "./pages/User";

const AppRoute: React.FC = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="/register" element={<Register />} />
        <Route path="/resetpassword" element={<ResetPassword />} />
        <Route path="/home" element={<Home />} />
        <Route path="/dashboard" element={<DashBoard />} />
        <Route path="/profile" element={<Profile />} />
        <Route path="/coursemarks" element={<CoursesMarks />} />
        <Route path="/tutorialmarks" element={<TutorialMarks />} />
        <Route path="/coursesteachers" element={<CoursesTeachers />} />
        <Route path="/attendance" element={<Attendance />} />
        <Route path="/customer" element={<Customer />} />
        <Route path="/employee" element={<Employee />} />
        <Route path="/user" element={<User />} />
      </Routes>
    </BrowserRouter>
  );
};
export default AppRoute;
