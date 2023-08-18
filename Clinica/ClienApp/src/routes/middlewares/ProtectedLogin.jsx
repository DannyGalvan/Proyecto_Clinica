import { useContext } from "react";
import { AuthContext } from "../../context/AuthContext.jsx";
import { Navigate } from "react-router-dom";

export const ProtectedLogin = ({ children }) => {
  const { authState } = useContext(AuthContext);

  if (authState.isLoggedIn) {
    return <Navigate to={"/"} />;
  }

  return children;
};
