using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBrewery.API.Controllers
{
    public abstract class BaseController<T> : ControllerBase
    {
        protected readonly IMapper _mapper;
        protected readonly IMediator _mediator;
        protected readonly ILogger<T> _logger;

        protected BaseController(IMapper mapper, IMediator mediator, ILogger<T> logger)
        {
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;
        }
    }
}
