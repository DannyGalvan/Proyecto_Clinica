import { Alert } from "react-bootstrap";

export const Response = ({ code, message }) => {
  return (
    <Alert variant={code ? "success" : "danger"}>
      <p className="text-center fw-bold text-danger h3">{message}</p>
    </Alert>
  );
};
