import "./App.css";
import { authorization, clinical } from "./axios/interceptors.js";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import { ReactQueryDevtools } from "@tanstack/react-query-devtools";
import { Router } from "./routes/Router.jsx";
import { icons } from "./util/iconsLibrari.js";
import { AuthProvider } from "./context/AuthContext.jsx";

window.addEventListener("beforeunload", () => {
  clinical.interceptors.response.eject(authorization);
});

icons();

const queryClient = new QueryClient({
  defaultOptions: {
    queries: {
      refetchOnReconnect: "always",
      refetchOnWindowFocus: false,
      cacheTime: 1000 * 60 * 5,
      staleTime: 1000 * 60 * 5,
    },
  },
});

function App() {
  return (
    <QueryClientProvider client={queryClient}>
      <ReactQueryDevtools initialIsOpen={false} />
      <AuthProvider>
        <Router />
      </AuthProvider>
    </QueryClientProvider>
  );
}

export default App;
