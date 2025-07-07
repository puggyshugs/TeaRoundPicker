# Architecture Decision Records (ADRs)

This document contains the architectural decisions made during the development of the Tea Round Picker application.

## ADR-001: Overall Architecture Pattern

**Context**: Need to design a scalable, maintainable architecture for a simple tea round picker application.

### Decision
Use a clean architecture pattern with clear separation of concerns:
- Frontend: React SPA
- Backend: .NET Core Web API with layered architecture
- Data: In-memory caching

### Rationale
- **Separation of Concerns**: Each layer has a single responsibility
- **Testability**: Dependencies can be easily mocked
- **Maintainability**: Changes in one layer don't affect others
- **Scalability**: Easy to add new features or change implementations

### Consequences
- **Positive**: Clean code structure, easy to test and maintain
- **Negative**: Slight over-engineering for a simple application
- **Neutral**: More files and folders to manage

---

## ADR-002: In-Memory Caching vs Database

**Context**: Need to decide on data persistence strategy for participant information.

### Decision
Use in-memory caching instead of a database for storing participant data.

### Rationale
- **Simplicity**: No database setup or management required
- **Performance**: Extremely fast read/write operations
- **Scope**: Application is simple with minimal data requirements
- **Deployment**: Easier deployment without database dependencies

### Consequences
- **Positive**: Fast performance, simple deployment, no database costs
- **Negative**: Data is lost when application restarts
- **Neutral**: Suitable for the current scope but may need revisiting for production

---

## ADR-003: Random Number Generation for Fairness

**Context**: Need to ensure fair selection of tea makers without bias.

### Decision
Use `System.Security.Cryptography.RandomNumberGenerator` for participant selection.

### Rationale
- **Fairness**: Cryptographically secure random number generation
- **No Bias**: Superior to `System.Random` for fairness-critical applications
- **Security**: Prevents prediction of future selections
- **Performance**: Minimal overhead for the use case

### Consequences
- **Positive**: Truly random and fair selections
- **Negative**: Slightly more complex than basic random
- **Neutral**: Industry standard for secure random generation

---

## ADR-004: React with TypeScript for Frontend

**Context**: Need to choose frontend technology stack.

### Decision
Use React with TypeScript for the frontend application.

### Rationale
- **Type Safety**: TypeScript provides compile-time error checking
- **Developer Experience**: Excellent tooling and IDE support
- **Component Model**: React's component model fits the UI needs
- **Ecosystem**: Large ecosystem of libraries and tools
- **Team Familiarity**: Common technology stack

### Consequences
- **Positive**: Type safety, great developer experience, maintainable code
- **Negative**: Additional compilation step, learning curve for TypeScript
- **Neutral**: Standard modern web development approach

---

## ADR-005: RESTful API Design

**Context**: Need to design API endpoints for frontend-backend communication.

### Decision
Use RESTful API design principles with conventional HTTP methods and status codes.

### Rationale
- **Standards**: Following REST conventions makes API predictable
- **HTTP Methods**: GET, POST map naturally to operations
- **Status Codes**: Standard codes provide clear response meanings
- **Simplicity**: Easy to understand and implement

### Consequences
- **Positive**: Standard, predictable API design
- **Negative**: Might be overkill for simple operations
- **Neutral**: Industry standard approach

---

## ADR-006: Client-Side State Management
 
**Context**: Need to manage application state on the frontend.

### Decision
Use React's built-in state management (useState) instead of external libraries.

### Rationale
- **Simplicity**: Application state is simple and localised
- **No Dependencies**: Avoid additional libraries for basic state needs
- **Performance**: React's state management is sufficient for the use case
- **Maintainability**: Fewer dependencies to manage

### Consequences
- **Positive**: Simple, no external dependencies, fast development
- **Negative**: May need refactoring if state becomes complex
- **Neutral**: Standard React approach for simple applications

---

## ADR-007: Error Handling Strategy
 
**Context**: Need consistent error handling across the application.

### Decision
Implement comprehensive error handling with:
- HTTP status codes for API responses
- User-friendly error messages in the frontend
- Validation at both frontend and backend levels

### Rationale
- **User Experience**: Clear error messages help users understand issues
- **Debugging**: Proper error handling aids in troubleshooting
- **Robustness**: Application handles edge cases gracefully
- **Standards**: Following HTTP status code conventions

### Consequences
- **Positive**: Better user experience, easier debugging, robust application
- **Negative**: Additional code for error handling scenarios
- **Neutral**: Standard practice for web applications

---

## ADR-008: No Authentication/Authorisation

**Context**: Decide whether to implement user authentication.

### Decision
No authentication or authorisation mechanisms implemented.

### Rationale
- **Scope**: Simple internal team tool
- **Simplicity**: Reduces complexity significantly
- **Trust Environment**: Used in trusted team environment
- **No Sensitive Data**: No sensitive information stored

### Consequences
- **Positive**: Simpler implementation, faster development
- **Negative**: No access control, anyone can modify data
- **Neutral**: Appropriate for internal team tools

---

## ADR-009: CORS Configuration

**Context**: Frontend and backend run on different ports during development.

### Decision
Configure CORS to allow frontend access to backend API.

### Rationale
- **Development**: Frontend (port 3000) needs to access backend (port 5027)
- **Security**: Still maintain some CORS restrictions
- **Flexibility**: Easy to adjust for different environments

### Consequences
- **Positive**: Enables frontend-backend communication
- **Negative**: Additional security consideration
- **Neutral**: Standard requirement for separated frontend/backend

---

## ADR-010: Deployment Strategy
 
**Context**: Needed to decide on deployment approach.

### Decision
Deploy frontend and backend as separate applications.

### Rationale
- **Scalability**: Can scale frontend and backend independently
- **Technology**: Different deployment requirements for React and .NET
- **Development**: Maintains clear separation of concerns
- **Flexibility**: Can deploy to different platforms if needed

### Consequences
- **Positive**: Independent scaling, clear separation, flexible deployment
- **Negative**: More complex deployment process, two applications to manage
- **Neutral**: Common pattern for modern web applications