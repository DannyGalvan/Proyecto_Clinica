import { BrowserRouter, Route, Routes } from "react-router-dom";
import { Index } from "../pages/home/index.jsx";
import { NotFound } from "../pages/error/NotFound.jsx";
import { URL_BASE_APP } from "../config/constants.js";
import { Layout } from "../containers/Layout.jsx";
import { ProtectedRoute } from "./middlewares/ProtectedRoute.jsx";
import { ProtectedLogin } from "./middlewares/ProtectedLogin.jsx";
import LoginPage from "../pages/auth/LoginPage.jsx";

export const Router = () => {
  return (
    <BrowserRouter basename={URL_BASE_APP}>
      <Layout>
        <Routes>
          <Route
            path={"/"}
            element={
              <ProtectedRoute>
                <Index />
              </ProtectedRoute>
            }
          />
          <Route
            path={"/login"}
            element={
              <ProtectedLogin>
                <LoginPage />
              </ProtectedLogin>
            }
          />
          <Route
            path="*"
            element={
              <NotFound
                Number={`Error 404`}
                Message="La Pagina Que Buscas No Existe"
              />
            }
          />
        </Routes>
      </Layout>
    </BrowserRouter>
  );
};
