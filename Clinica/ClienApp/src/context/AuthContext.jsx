import { createContext, useReducer } from "react";
import { AuthReducer } from "./AuthReducer.js";
import { setAuthorization } from "../axios/interceptors.js";

// Initial State
export const authInitialState = {
  isLoggedIn: false,
  email: "",
  token: "",
  name: "",
  idUser: 0,
  rol: 0,
  operations: [],
};

// we define what our context looks like
export const AuthContextProps = {
  authState: authInitialState,
  signIn: () => {},
  logout: () => {},
};

// create the context
export const AuthContext = createContext(AuthContextProps);

// State Provider Component
export const AuthProvider = ({ children }) => {
  const [authState, dispatch] = useReducer(
    AuthReducer,
    authInitialState,
    () => {
      const state =
        JSON.parse(window.localStorage.getItem("@auth")) ?? authInitialState;
      setAuthorization(state.token);
      return state;
    },
  );

  const signIn = (login) => {
    dispatch({ type: "signIn", payload: login });
  };
  const logout = () => {
    dispatch({ type: "logout" });
  };

  return (
    <AuthContext.Provider
      value={{
        authState,
        signIn,
        logout,
      }}
    >
      {children}
    </AuthContext.Provider>
  );
};
