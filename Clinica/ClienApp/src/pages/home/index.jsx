import { Proof } from "../../components/Proof.jsx";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faUserSecret } from "@fortawesome/free-solid-svg-icons";

export const Index = () => {
  return (
    <div className="page-wrap d-flex flex-column justify-content-center align-items-center">
      <Proof />
      <FontAwesomeIcon icon={faUserSecret} />
      <Proof />
      <FontAwesomeIcon icon={faUserSecret} />
      <Proof />
      <FontAwesomeIcon icon={faUserSecret} />
    </div>
  );
};
