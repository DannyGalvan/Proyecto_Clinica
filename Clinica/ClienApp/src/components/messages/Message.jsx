import { Col, Row } from "react-bootstrap";

export const Message = ({ message, typo }) => {
  const color = typo != 0 ? "success" : "danger";

  return (
    <Row>
      <Col md="12">
        <p className={`text-center fw-bold text-${color}`}>{message}</p>
      </Col>
    </Row>
  );
};
