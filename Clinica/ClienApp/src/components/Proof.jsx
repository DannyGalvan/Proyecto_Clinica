import { useState } from "react";
import { clinical } from "../axios/interceptors.js";
import { useQuery } from "@tanstack/react-query";
import Loading from "../pages/load/Loading.jsx";

export const Proof = () => {
  const [count, setCount] = useState(0);

  const {
    data: users,
    isLoading,
    isFetching,
  } = useQuery({
    queryFn: () => clinical.get("/User"),
    queryKey: ["users"],
  });

  return isLoading || isFetching ? (
    <Loading />
  ) : (
    <div>
      <button className="btn btn-primary" onClick={() => setCount(count + 1)}>
        Count {count}
      </button>
      <pre>{JSON.stringify(users, null, 5)}</pre>
    </div>
  );
};
