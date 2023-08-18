import { Header } from "./Headear.jsx";
import { useContext } from "react";
import { AuthContext } from "../context/AuthContext.jsx";

export const Layout = ({ children }) => {
  const { authState } = useContext(AuthContext);
  return (
    <div>
      {authState.isLoggedIn && <Header />}
      <main className="mt-5 pt-5" id={"ROOT"}>
        {children}
      </main>
    </div>
  );
};
