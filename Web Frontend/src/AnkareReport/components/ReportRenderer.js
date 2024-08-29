import { useRenderer } from "../hooks/useRenderer";

export function ReportRenderer({ layout, data }) {
  const { renderer, rendererRef } = useRenderer({ layout, data });

  console.log("Renderer: ", rendererRef);
  console.log("layout: ", layout);
  console.log("data: ", data);


  return (
    <div ref={rendererRef} style={{ height: '100%' }}></div>
  );
}
