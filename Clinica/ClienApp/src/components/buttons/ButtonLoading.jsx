import { Button, Spinner } from "react-bootstrap";

export const ButtonLoading = ({ loading, size, type, variant, text }) => {
  return (
    <Button variant={`${variant} bg-gradient`} size={size} type={type}>
      {loading && (
        <Spinner
          as="span"
          animation="border"
          size="sm"
          role="status"
          aria-hidden="true"
        />
      )}
      {text}
    </Button>
  );
};
