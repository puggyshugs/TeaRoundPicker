# Technical Decision Log

This document tracks all technical decisions made during the development of the Tea Round Picker application.

## Decision Summary

| Decision | Status |
|----------|--------|
| Clean Architecture Pattern | ✅ Implemented 
| In-Memory Caching | ✅ Implemented 
| Cryptographic Random Selection | ✅ Implemented
| React + TypeScript Frontend | ✅ Implemented 
| RESTful API Design | ✅ Implemented
| No Authentication | ✅ Implemented
| Separate Deployment | ✅ Implemented 

## Implementation Details

### Backend Architecture Decisions

#### 1. Layered Architecture
**Decision**: Implement a three-layer architecture (API, Service, Domain)
**Reasoning**: 
- Clear separation of concerns
- Easier testing and maintenance
- Follows .NET best practices

**Implementation**:
```
TeaRoundPicker.Api/          # Controllers, HTTP handling
TeaRoundPicker.Services/     # Business logic
TeaRoundPicker.Domain/       # Models and enums
```

#### 2. Dependency Injection
**Decision**: Use ASP.NET Core's built-in DI container
**Reasoning**:
- Standard .NET approach
- Simplifies testing
- Manages object lifetimes

**Implementation**:
```csharp
// Program.cs
builder.Services.AddScoped<ICacheService, CacheService>();
builder.Services.AddSingleton<ICache, Cache>();
```

#### 3. Error Handling Strategy
**Decision**: Use HTTP status codes with descriptive messages
**Reasoning**:
- RESTful standard
- Clear error communication
- Easy to handle in frontend

**Implementation**:
```csharp
if (participant == null)
    return NotFound(SuccessMessages.ParticipantNotFound);
```

### Frontend Architecture Decisions

#### 1. Component Structure
**Decision**: Single-page application with one main component
**Reasoning**:
- Simple application scope
- Minimal state management needs
- Fast development

**Implementation**:
```typescript
// App.tsx - Main component handling all functionality
function App() {
  // State management
  // API calls
  // UI rendering
}
```
#### 2. API Communication
**Decision**: Use Fetch API with separate API module
**Reasoning**:
- Native browser API
- No additional dependencies
- Clean separation of concerns

**Implementation**:
```typescript
// teaApi.ts
export async function getAllParticipants() {
  const res = await fetch(`${API_BASE_URL}/api/participant/getAll`);
  return res.json();
}
```

### Data Management Decisions

#### 1. In-Memory Storage
**Decision**: Use in-memory caching instead of database
**Reasoning**:
- Simple deployment
- Fast performance
- Suitable for application scope

**Trade-offs**:
- ✅ No database setup required
- ✅ Excellent performance
- ❌ Data lost on restart
- ❌ Not suitable for production scale

#### 2. Data Validation
**Decision**: Implement validation at both frontend and backend
**Reasoning**:
- User experience (immediate feedback)
- Security (server-side validation)
- Data integrity

**Implementation**:
```typescript
// Frontend validation
if (!nameInput.trim()) {
  setError('Please enter at least one name');
  return;
}

// Backend validation
if (string.IsNullOrWhiteSpace(name))
  return BadRequest("Participant name cannot be empty.");
```

### Security Decisions

#### 1. No Authentication
**Decision**: Omit authentication and authorisation
**Reasoning**:
- Internal team tool
- No sensitive data
- Simplifies implementation

**Risks**:
- Anyone can access the application
- No audit trail of who made changes
- Not suitable for external use

#### 2. CORS Configuration
**Decision**: Enable CORS for development
**Reasoning**:
- Frontend and backend on different ports
- Enable cross-origin requests
- Standard development practice

**Implementation**:
```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
```

### Deployment Decisions

#### 1. Containerisation
**Decision**: Not implemented initially
**Reasoning**:
- Simple deployment requirements
- Development focus
- Can be added later

**Future Consideration**:
```dockerfile
# Dockerfile for backend
FROM mcr.microsoft.com/dotnet/aspnet:9.0
COPY publish/ .
ENTRYPOINT ["dotnet", "TeaRoundPicker.Api.dll"]
```

## Lessons Learned

### What Worked Well
1. **Clean Architecture**: Easy to understand and maintain
2. **Type Safety**: TypeScript caught many errors early
3. **Simple State Management**: No over-engineering
4. **Cryptographic Random**: Ensures fairness

### What Could Be Improved
1. **Data Persistence**: In-memory storage is limiting
2. **Error Handling**: Could be more sophisticated
3. **Testing**: Needs comprehensive test suite
4. **Configuration**: Hard-coded values should be configurable

### Future Recommendations
1. **Database Integration**: For production use
2. **Authentication**: For access control
3. **Logging**: For debugging and monitoring
6. **Rate Limiting**: To prevent misuse

## Change Request Process

For future architectural changes:

1. **Assess Impact**: Determine if change affects existing decisions
2. **Create ADR**: Document new decision with context and rationale
3. **Update Documentation**: Reflect changes in all relevant docs
4. **Implement**: Follow standard development process
5. **Review**: Validate decision achieved desired outcomes
